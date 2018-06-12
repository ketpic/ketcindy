
all: template1basic.cdy template2advanced.cdy

template1basic.cdy: template1basic/private/de.cinderella/scripts/Init/0/KETlib.cs
	rm -f template1basic.cdy
	cd template1basic && zip -r ../template1basic.cdy *

template2advanced.cdy: template2advanced/private/de.cinderella/scripts/Init/0/KETlib.cs
	rm -f template2advanced.cdy
	cd template2advanced && zip -r ../template2advanced.cdy *

template1basic/private/de.cinderella/scripts/Init/0/KETlib.cs: Scriptkelib.txt
	cp Scriptkelib.txt template1basic/private/de.cinderella/scripts/Init/0/KETlib.cs

template2advanced/private/de.cinderella/scripts/Init/0/KETlib.cs: Scriptkelib.txt
	cp Scriptkelib.txt template2advanced/private/de.cinderella/scripts/Init/0/KETlib.cs

.PHONY: all

