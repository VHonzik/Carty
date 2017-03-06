local action = _ACTION or ""

workspace "Carty"
  configurations { "Debug", "Release" }
  location("../" .. action)

project "Carty"
  kind "SharedLib"
  language "C#"
  location("../" .. action .. "/Carty")
  dotnetframework "3.5"

  targetdir "../../bin"

  vpaths { ["*"] = "../../src" }
  files { "../../src/**.cs"}
  
  links { "UnityEditor", "UnityEngine"}
  libdirs  { "../../../SampleGame/Library/UnityAssemblies/" }  
  
  postbuildcommands { "copy /Y \"$(TargetDir)$(TargetName).dll\" \"$(SolutionDir)..\\..\\..\\SampleGame\\Assets\\Carty\\$(TargetName).dll\"" }


  filter "configurations:Debug"
    defines { "DEBUG" }
    flags { "Symbols" }

  filter "configurations:Release"
    defines { "NDEBUG" }
    optimize "On"