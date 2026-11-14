using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Octokit;
using Spectre.Console;

namespace LabelMaker;

public static class GitHubApi
{
    /// <summary>
    /// The new labels to create.
    /// </summary>
    private static readonly NewLabel[] _newLabels = [
        new NewLabel (name: "priority:1", color: "CE0E18") { Description = "Highest" },
        new NewLabel (name: "priority:2", color: "D85A10") { Description = "High" },
        new NewLabel (name: "priority:3", color: "E0A000") { Description = "Medium" },
        new NewLabel (name: "priority:4", color: "7B9EC4") { Description = "Low" },
        new NewLabel (name: "priority:5", color: "A0A7B0") { Description = "Lowest" },
        ];

    public static async Task CreateLabelsAsync(string owner, string repository, string personalAccessToken)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(owner);
        ArgumentException.ThrowIfNullOrWhiteSpace(repository);
        ArgumentException.ThrowIfNullOrWhiteSpace(personalAccessToken);

        // Set up the GitHub client.
        var githubClient = new GitHubClient(new ProductHeaderValue("LabelMaker", "1.0"));
        githubClient.Credentials = new Credentials(personalAccessToken);


        //
        // Get the existing labels from the repo.
        //

        var existingLabels = await githubClient.Issue.Labels.GetAllForRepository(owner: owner, name: repository);

        // Get a case-insensitive, distinct list of label names.
        var existingLabelNames = existingLabels
            .Select(l => l.Name)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        // Only create new labels where the name does not yet exist.
        var newLabelsToCreate = _newLabels
            .Where(nl => !existingLabelNames.Contains(nl.Name))
            .ToArray();


        //
        // Create the new labels.
        //

        foreach (var newLabel in newLabelsToCreate)
        {
            AnsiConsole.MarkupLineInterpolated($"[#{newLabel.Color}]Creating label with name {newLabel.Name}, color {newLabel.Color}, and description {newLabel.Description}...[/]");
            var response = await githubClient.Issue.Labels.Create(owner: owner, name: repository, newLabel: newLabel);
            AnsiConsole.MarkupLineInterpolated($"[#{newLabel.Color}]Done. Response: {JsonSerializer.Serialize(response)}[/]");
        }
    }
}