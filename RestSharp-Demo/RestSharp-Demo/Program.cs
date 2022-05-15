using RestSharp;
using System;
using System.Collections.Generic;
using System.Text.Json;

var client = new RestClient("https://api.github.com");

string IssueURL = "repos/shestakov14/API-Collections/issues";
var IssueRequest = new RestRequest(IssueURL);

string RepoURL = "users/shestakov14/repos";
var RepoRequest = new RestRequest(RepoURL);

var IssueResponse = await client.ExecuteAsync(IssueRequest);
var RepoResponse = await client.ExecuteAsync(RepoRequest);

var issues = JsonSerializer.Deserialize<List<Issues>>(IssueResponse.Content);
var repos = JsonSerializer.Deserialize<List<Repo>>(RepoResponse.Content);

int countIssues = 0;
int countRepos = 0;

Console.WriteLine("---REPOS SECTION---");
foreach (var repo in repos)
{
    countRepos++;
    Console.WriteLine("REPO NAME: " + repo.name);
    Console.WriteLine("REPO ID: " + repo.id);
    Console.WriteLine("PRIVATE: " + repo.IsPrivate);
    Console.WriteLine("REPO URL: " + repo.html_url);
    Console.WriteLine("*****");

}


Console.WriteLine("---ISSUE SECTION---");

foreach (var issue in issues)
{
    countIssues++;
    Console.WriteLine("ISSUE NUMBERS: " + issue.number);
    Console.WriteLine("ISSUE ID: " + issue.id);
    Console.WriteLine("ISSUE Title: " + issue.title);
    Console.WriteLine("ISSUE URL: " + issue.html_url);
    Console.WriteLine("*****");
}

Console.WriteLine("STATUS CODE: " + RepoResponse.StatusCode);
Console.WriteLine("Repos count = " + countRepos);
Console.WriteLine();
Console.WriteLine("STATUS CODE: " + IssueResponse.StatusCode);
Console.WriteLine("Issues count = " + countIssues);
