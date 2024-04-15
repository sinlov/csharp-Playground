.PHONY: test check clean build dist all
# Makefile root
# can change this by env:ENV_CI_DIST_VERSION use and change by env:ENV_CI_DIST_MARK by CI
ENV_DIST_VERSION=latest
ENV_DIST_MARK=

ROOT_NAME?=dotnet-basic

## run info start
ENV_RUN_INFO_HELP_ARGS=-h
ENV_RUN_INFO_ARGS=
## run info end

all: env

env:
	@echo "== project env info start =="
	@echo ""
	@echo "ENV_DIST_VERSION                          ${ENV_DIST_VERSION}"
	@echo "ENV_DIST_MARK                             ${ENV_DIST_MARK}"
	@echo ""
	@echo "== project env info end =="
	@echo "dotnet version"
	@dotnet --version

cleanBuild:
	 dotnet clean
	 dotnet clean --configuration Release

cleanTest:
	@$(RM) coverage.xml
	@$(RM) build/report

clean: cleanTest cleanBuild
	@echo "~> clean finish"

cleanAll: clean
	@echo "~> clean all finish"

init: dep
	@echo "~> start init this project"
	@echo "-> check version"
	@echo "dotnet version"
	@dotnet --version

dep:
	dotnet restore

testList:
	dotnet test --list-tests

testDotnet:
	dotnet test

test: testDotnet

buildDebug:
	dotnet build --configuration Debug --no-restore

buildRelease:
	dotnet build --configuration Release --no-restore

ci: test buildDebug

helpProjectRoot:
	@echo "Help: Project root Makefile"
ifeq ($(OS),Windows_NT)
	@echo ""
	@echo "warning: other install make cli tools has bug, please use: scoop install main/make"
	@echo " run will at make tools version 4.+"
	@echo "windows use this kit must install tools blow:"
	@echo ""
	@echo "https://scoop.sh/#/apps?q=busybox&s=0&d=1&o=true"
	@echo "-> scoop install main/busybox"
	@echo "and"
	@echo "https://scoop.sh/#/apps?q=shasum&s=0&d=1&o=true"
	@echo "-> scoop install main/shasum"
	@echo ""
endif
	@echo "-- now build name: ${ROOT_NAME} version: ${ENV_DIST_VERSION}"
	@echo "-- distTestOS or distReleaseOS will out abi as: ${ENV_DIST_GO_OS} ${ENV_DIST_GO_ARCH} --"
	@echo ""
	@echo "~> make env                 - print env of this project"
	@echo "~> make init                - check base env of this project"
	@echo "~> make dep                 - check and install by go mod"
	@echo "~> make clean               - remove build binary file, log files, and testdata"
	@echo "~> make test                - run test case"
	@echo "~> make ci                  - run CI tools tasks"

help: helpProjectRoot
ifeq ($(OS),Windows_NT)
	@echo ""
	@echo "windows use this kit must install"
	@echo "https://scoop.sh/#/apps?q=gow&s=0&d=1&o=true"
	@echo "scoop install gow"
	@echo "and"
	@echo "https://scoop.sh/#/apps?q=busybox&s=0&d=1&o=true"
	@echo "# scoop install shasum"
endif
	@echo ""
	@echo "-- more info see Makefile include: MakeGoMod.mk MakeGoTest.mk MakeGoTestIntegration.mk --"