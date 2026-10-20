namespace CleanCodeShenaningans.DesignPatterns.Structural;


public class AgentExecutionComposite
{
    protected List<AgentExecutionComposite> SubTasks { get; set; }

    public virtual void ExecuteTask()
    {
        Console.WriteLine("Agent Executing");

        foreach (AgentExecutionComposite task in SubTasks)
        {
            task.ExecuteTask();
        }
    }
}

public class SubAgentExecutionComposite : AgentExecutionComposite
{
    public override void ExecuteTask()
    {
        Console.WriteLine("SubAgent Executing");


        foreach (AgentExecutionComposite task in SubTasks)
        {
            task.ExecuteTask();
        }
    }
}

public class ToolExecutionComposite : AgentExecutionComposite
{
    public override void ExecuteTask()
    {
        Console.WriteLine("Tool executed");
    }
}

