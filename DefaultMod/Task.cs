using System;
using System.Reflection;
using GooseShared;
using MoonSharp.Interpreter;

namespace GooseLua
{
    class Task : GooseTaskInfo
    {
        private Script script;
        private Closure runTask;

        public static void Register(Script script, string id, string name, string description, bool canBePickedRandomly, Closure runTask)
        {
            // create task
            Task task = new Task()
            {
                script = script,
                taskID = id,
                shortName = name,
                description = description,
                canBePickedRandomly = canBePickedRandomly,
                runTask = runTask
            };
            // hack to register task
            Type type = Type.GetType("GooseDesktop.Refactor.GooseTasks.GooseTaskDatabase, GooseDesktop", false);
            if (type == null)
            {
                throw new ScriptRuntimeException("Could not find GooseTaskDatabase");
            }
            // unlock task database
            FieldInfo field = type.GetField("taskDeck", BindingFlags.Static | BindingFlags.NonPublic);
            if (field != null)
            {
                field.SetValue(null, null);
            }
            // register task
            MethodInfo method = type.GetMethod("RegisterTask", BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public);
            if (method == null)
            {
                throw new ScriptRuntimeException("Could not find GooseTaskDatabase.RegisterTask");
            }
            object[] args = { task };
            method.Invoke(null, args);
        }

        public Task()
        {
            taskID = "dummyLuaTask";
            shortName = "Dummy Lua Task";
            description = "placeholder for tasks written in Lua - do not use directly";
            canBePickedRandomly = false;
        }

        public override GooseTaskData GetNewTaskData(GooseEntity s)
        {
            return new TaskData()
            {
                value = DynValue.NewTable(script)
            };
        }

        public override void RunTask(GooseEntity s)
        {
            TaskData data = (TaskData)s.currentTaskData;
            try
            {
                runTask.Call(data.value);
            }
            catch (ScriptRuntimeException ex)
            {
                _G.HandleScriptException(ex);
            }
        }

        internal class TaskData : GooseTaskData
        {
            public DynValue value;
        }
    }
}
