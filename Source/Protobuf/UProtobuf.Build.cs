// Copyright 1998-2019 Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;
using System.IO;

public class UProtobuf : ModuleRules
{
	// Path to third party folder
	private string ThirdPartyPath
	{
		get { return Path.GetFullPath(Path.Combine(ModuleDirectory, "..", "ThirdParty")); }
	}

	// Path to include directories
    private string HeaderPath
    {
        get { return Path.GetFullPath(Path.Combine(ModuleDirectory, ThirdPartyPath, "include")); }
    }

	// Path to messages
	private string MsgsPath
	{
		get { return Path.GetFullPath(Path.Combine(ModuleDirectory, ThirdPartyPath, "proto")); }
	}

	public UProtobuf(ReadOnlyTargetRules Target) : base(Target)
	{
		// We are just setting up paths for pre-compiled binaries.
		//Type = ModuleType.External;

		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;

		bEnableUndefinedIdentifierWarnings = false;
		bEnableShadowVariableWarnings = false;
		//bEnableExceptions = true;

		PublicIncludePaths.AddRange(
			new string[] {
				// ... add public include paths required here ...
                HeaderPath,
				MsgsPath,
			}
			);
				
		
		PrivateIncludePaths.AddRange(
			new string[] {
                // ... add other private include paths required here ...
                HeaderPath,
				MsgsPath,
			}
			);
			
		
		PublicDependencyModuleNames.AddRange(
			new string[]
			{
				"Core",
				// ... add other public dependencies that you statically link with here ...
			}
			);
			
		
		PrivateDependencyModuleNames.AddRange(
			new string[]
			{
				// ... add private dependencies that you statically link with here ...	
			}
			);
		
		
		DynamicallyLoadedModuleNames.AddRange(
			new string[]
			{
				// ... add any modules that your module loads dynamically here ...
			}
			);


        if (Target.Platform == UnrealTargetPlatform.Win64)
        {
			// .lib
			string LibsDir = Path.Combine(ModuleDirectory, ThirdPartyPath, "lib", "Release");
			PublicAdditionalLibraries.Add(Path.Combine(LibsDir, "libprotobuf.lib"));

		}
        else if (Target.Platform == UnrealTargetPlatform.Linux)
        {
			// .lib
			string LibsDir = Path.Combine(ModuleDirectory, ThirdPartyPath, "lib", "Release");
			PublicAdditionalLibraries.Add(Path.Combine(LibsDir, "libprotobuf.a"));
		}
    }
}
