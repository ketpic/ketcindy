WORK := $(abspath ../../../work)

all: $(WORK)/template1basic.cdy $(WORK)/template2advanced.cdy

$(WORK)/template1basic.cdy: $(WORK)/Scriptkelib.txt
	rm -rf tmp
	mkdir tmp
	cd tmp && unzip $(WORK)/template1basic.cdy
	cp $(WORK)/Scriptkelib.txt tmp/private/de.cinderella/scripts/Init/0/KETlib.cs
	rm $(WORK)/template1basic.cdy
	cd tmp && zip -r $(WORK)/template1basic.cdy *
	rm -rf tmp

$(WORK)/template2advanced.cdy: $(WORK)/Scriptkelib.txt
	rm -rf tmp
	mkdir tmp
	cd tmp && unzip $(WORK)/template2advanced.cdy
	cp $(WORK)/Scriptkelib.txt tmp/private/de.cinderella/scripts/Init/0/KETlib.cs
	rm $(WORK)/template2advanced.cdy
	cd tmp && zip -r $(WORK)/template2advanced.cdy *
	rm -rf tmp

.PHONY: all


