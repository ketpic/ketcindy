WORK := $(abspath ../../../work)

all: $(WORK)/template1basic.cdy $(WORK)/template2advanced.cdy

$(WORK)/template1basic.cdy: template1basic/private/de.cinderella/scripts/Init/0/KETlib.cs
	rm -f template1basic.cdy
	cd template1basic && zip -r $(WORK)/template1basic.cdy *
	rm template1basic/private/de.cinderella/scripts/Init/0/KETlib.cs

$(WORK)/template2advanced.cdy: template2advanced/private/de.cinderella/scripts/Init/0/KETlib.cs
	rm -f template2advanced.cdy
	cd template2advanced && zip -r $(WORK)/template2advanced.cdy *
	rm template2advanced/private/de.cinderella/scripts/Init/0/KETlib.cs

template1basic/private/de.cinderella/scripts/Init/0/KETlib.cs: $(WORK)/Scriptkelib.txt
	cp $(WORK)/Scriptkelib.txt template1basic/private/de.cinderella/scripts/Init/0/KETlib.cs

template2advanced/private/de.cinderella/scripts/Init/0/KETlib.cs: $(WORK)/Scriptkelib.txt
	cp $(WORK)/Scriptkelib.txt template2advanced/private/de.cinderella/scripts/Init/0/KETlib.cs

.PHONY: all


