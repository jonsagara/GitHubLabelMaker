using System.Threading.Tasks;

namespace LabelMaker;

public class Program
{
    public static async Task<int> Main(string[] args)
    {
        const string owner = "jonsagara";
        const string repository = "Sagara.Core";

        // Create a fine-grained personal access token with the following permissions:
        // * Issues: read and write
        // * Pull requests: read and write (a pull request is still an issue)
        const string personalAccessToken = "";

        await GitHubApi.CreateLabelsAsync(
            owner: owner,
            repository: repository,
            personalAccessToken: personalAccessToken
            );

        return 0;
    }
}