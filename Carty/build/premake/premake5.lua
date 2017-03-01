local action = _ACTION or ""

workspace "Carty"
  configurations { "Debug", "Release" }
  location("../" .. action)

project "Carty"
  kind "SharedLib"
  language "C#"
  location("../" .. action .. "/Carty")

  targetdir "../../bin"

  vpaths { ["*"] = "../../src" }
  files { "../../src/**.cs"}
  
  links { "UnityEditor", "UnityEngine"}
  libdirs  { "../../../SampleGame/Library/UnityAssemblies/" }  

  filter "configurations:Debug"
    defines { "DEBUG" }
    flags { "Symbols" }

  filter "configurations:Release"
    defines { "NDEBUG" }
    optimize "On"