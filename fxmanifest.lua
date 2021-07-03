fx_version "cerulean"
games { "gta5" }

author "fixterjake"
description "Phoenix-Character"
version "0.0.1"

ui_page "ui/character.html"

files {
	"ui/character.html"
}

server_script "Phoenix.Character.Server.net.dll"
client_script "Phoenix.Character.Client.net.dll"