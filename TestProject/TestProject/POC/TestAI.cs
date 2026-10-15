using Microsoft.Extensions.AI;
using OllamaSharp;
using System;
using System.Threading.Tasks;

namespace TestProject.POC;

public class TestAI
{
    private string _uri;
    private string _model;

    public TestAI(string uri = "http://localhost:11434", string model = "llama3.1" )
    {
        _uri = uri;
        _model = model;
    }

    public async Task SendPrompt(string prtpt)
    {
        var uri = new Uri(_uri);
        var modelName = _model;

        IChatClient chatClient = new OllamaApiClient(uri, modelName);

        var response = await chatClient.GetResponseAsync(prtpt);
        Console.WriteLine(response.Text);
    }

}

