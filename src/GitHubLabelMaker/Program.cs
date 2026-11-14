using System.Threading.Tasks;

namespace LabelMaker;

public class Program
{
    public static async Task<int> Main(string[] args)
    {
        const string owner = "jonsagara";
        const string repository = "Sagara.Core";

        // Create a fine-grained personal access token with the following permissions:
        // 1. Log in to GitHub and click on your profile picture in the top-right corner.
        // 2. Select Settings from the dropdown menu.
        // 3. Scroll down to the bottom of the left sidebar and click on Developer settings.
        // 4. Expand the Personal access tokens dropdown menu in the left sidebar.
        // 5. Click on Fine-grained tokens.
        // 6. Click the Generate new token button.
        // 7. Fill out the token details:
        //    - Token name: Give it a descriptive name so you remember what it's used for.
        //    - Expiration: Choose an expiration date (it is a best practice to avoid setting tokens to never expire).
        //    - Resource owner: Select your personal account or an organization.
        //    - Repository access: Choose whether the token should apply to All repositories or Only select repositories.
        // 8. Configure Permissions: Scroll down to select the specific repository and account permissions (scopes) your token needs.
        //    - Issues: read and write
        //    - Pull requests: read and write (a pull request is still an issue)
        // 9. Delete the token when you're done.
        const string personalAccessToken = "";

        await GitHubApi.CreateLabelsAsync(
            owner: owner,
            repository: repository,
            personalAccessToken: personalAccessToken
            );

        return 0;
    }
}