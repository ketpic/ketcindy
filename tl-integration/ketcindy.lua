#!/usr/bin/env texlua

-- KETCindy starter script

-- (C) 2017 Norbert Preining
-- Licensed under the same license terms as ketpic itself, that is GPLv3+

kpse.set_program_name('kpsewhich')
if arg[1] == nil then
    print("no input")
    os.exit(1)
end

function ketcdyUsage()
   print([[
Usage:	ketcindy [options...] [cindyscript]
]])
end

-- file_exists(name), file_notexists(name): check the file name exists or not
function file_exists(name)
   local fh = io.open(name,"r")
   if fh ~= nil then
      io.close(fh)
      return true
   else
      return false
   end
end

-- Split a path into file and directory component
function splitpath(file)
  local path, name = string.match(file, "^(.*)/([^/]*)$")
  if path then
    return path, name
  else
    return ".", file
  end
end

-- Arguably clearer names
function basename(file)
  return(select(2, splitpath(file)))
end

function dirname(file)
  return(select(1, splitpath(file)))
end

function check_env_PATH()
   if os.getenv("PATH") == false then
      print("Cannot find environment variable: PATH")
      return false
   end

   local ph = io.popen("kpsewhich -version")
   if ph == nil then
      print("Cannot find kpsewhich in PATH")
      return false
   end
   io.close(ph)

   return true
end

function run_cinderella(cdyfile)
   if file_exists(cdyfile) == false then
      print("Cannot find CindyScript: " .. cdyfile)
      return false
   end

   if os.execute(CDYBIN .. " " .. cdyfile) == false then
      print("Cannot find Cinderella binary: " .. CDYBIN)
      return false
   end
   return true
end

function ketcdyMain()
   if check_env_PATH() == false then return false end

   if CDYBIN == "" then
      if os.name == 'windows' then
         -- FIXME: Please tell me the full path of Cinderella2.exe
         CDYBIN = "Cinderella2.exe"
         CDYPLUGDIR = dirname(CDYBIN) .. "/Plugins/"
      elseif os.name == 'macosx' then
         CDYBIN = "/Applications/Cinderella2.app/Contents/MacOS/Cinderella2"
         CDYPLUGDIR = dirname(CDYBIN) .. "/../PlugIns/"
      elseif os.name == 'linux' then
         CDYBIN = os.execute("which Cinderella2")
         CDYPLUGDIR = dirname(CDYBIN) .. "/Plugins/"
      end
   end
   CDYPLUGDIRHEAD = CDYPLUGDIR .. "ketcindy.ini"
   -- CDYPLUGDIRHEAD = CDYPLUGDIR .. "dirhead.txt"

   if file_exists(CDYPLUGDIRHEAD) then
      print(kpse.find_file("KetCindyPlugin.jar", 'texmfscripts'))
   else
   end

   print(CDYPLUGDIR)
   os.exit(0)
   
   if run_cinderella(CDYSCRT) == false then return false end
   return true
end

CDYBIN = "" -- Cinderella2 binary
CDYPLUGDIR = "" -- Cinderella2's Plug-Ins directory
CDYPLUGDIRHEAD = "" -- dirhead.txt Cinderella2's Plug-Ins directory
-- working directory
if os.name == 'windows' then
   WORKDIR = os.getenv("homepath") .. "/ketcindy/"
else
   WORKDIR = os.getenv("HOME") .. "/ketcindy/"
end

CDYSCRT = "" -- CindyScript file
exit_code = 0
narg = 1
repeat
   this_arg = arg[narg]
   if this_arg == "--help" then
      ketcdyUsage()
      os.exit(0)
   elseif this_arg == "-h" then
      ketcdyUsage()
      os.exit(0)
   elseif this_arg == "-c" then
      narg = narg+1
       CDYBIN = arg[narg]
   -- 
   elseif this_arg == "--debug" then
      with_debug = true
   else
      CDYSCRT = this_arg 
   end --if this_arg == ...
   narg = narg+1
until narg > #arg

-- TEMPDIR = mktempdir()
if ketcdyMain() == false then exit_code = 1 end
os.exit(exit_code)
-- end of file
