﻿
#r "System.Xml"
#r "System.Configuration"

//#r "../packages/FAKE/tools/FakeLib.dll"
//#r "../packages/LibGit2Sharp.0.17.0.0/lib/net35/LibGit2Sharp.dll"
//#r "../packages/SourceLink.Fake/tools/SourceLink.dll"
//#r "../packages/SourceLink.Fake/tools/SourceLink.Git.dll"
#I __SOURCE_DIRECTORY__
#r "SourceLink.Build.Framework.dll"
#r "SourceLink.Build.dll"
#r "LibGit2Sharp.dll"
#r "SourceLink.dll"
#r "SourceLink.Git.dll"

#if MONO
#else
#r "System.Net.Http"
#r "System.Activities"
#r "Microsoft.TeamFoundation.Build.Client"
#r "Microsoft.TeamFoundation.Build.Workflow"
#r "Microsoft.TeamFoundation.Client"
#r "Microsoft.TeamFoundation.Common"
#r "Microsoft.TeamFoundation.TestManagement.Client"
#r "Microsoft.TeamFoundation.VersionControl.Client"
#r "Microsoft.TeamFoundation.VersionControl.Common"
#r "Microsoft.TeamFoundation.WorkItemTracking.Client"
#r "Microsoft.VisualStudio.Services.Common"
#r "Microsoft.TeamFoundation.SourceControl.WebApi"
#endif

//#r "../packages/SourceLink.Fake/tools/SourceLink.Tfs.dll" // in dev
#r "SourceLink.Tfs.dll"