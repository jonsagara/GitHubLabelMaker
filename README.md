# GitHubLabelMaker

A simple C# console application that uses the GitHub API (via [Octokit](https://github.com/octokit/octokit.net)) to create a standard set of issue labels in a repository. This makes setting up issues for a new project easier.

Labels that already exist in the repository (matched by name, case-insensitively) are skipped. Output is colored with [Spectre.Console](https://spectreconsole.net/) to match each label's color.

## Labels

The labels are defined in [`src/GitHubLabelMaker/GitHubApi.cs`](src/GitHubLabelMaker/GitHubApi.cs):

| Label | Name         | Color    | Description |
|-------|--------------|----------|-------------|
| ![priority:1](https://img.shields.io/badge/priority%3A1-CE0E18) | `priority:1` | `CE0E18` | Highest     |
| ![priority:2](https://img.shields.io/badge/priority%3A2-D85A10) | `priority:2` | `D85A10` | High        |
| ![priority:3](https://img.shields.io/badge/priority%3A3-E0A000) | `priority:3` | `E0A000` | Medium      |
| ![priority:4](https://img.shields.io/badge/priority%3A4-7B9EC4) | `priority:4` | `7B9EC4` | Low         |
| ![priority:5](https://img.shields.io/badge/priority%3A5-A0A7B0) | `priority:5` | `A0A7B0` | Lowest      |

## Requirements

- .NET SDK 11.0.100 (see [`global.json`](global.json))
- A GitHub fine-grained personal access token with these repository permissions:
  - Issues: read and write
  - Pull requests: read and write

## Usage

1. Edit [`src/GitHubLabelMaker/Program.cs`](src/GitHubLabelMaker/Program.cs) and set `owner`, `repository`, and `personalAccessToken`. Don't commit your token.
2. Run it:

   ```shell
   dotnet run --project src/GitHubLabelMaker
   ```

(Ironically, I did not create these labels for this repo, as I don't see it being much more than a one-off.)
