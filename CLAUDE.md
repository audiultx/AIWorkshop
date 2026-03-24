# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Repository Purpose

This is a multi-language workshop repository ("AIWorkshop") intended to demonstrate AI-driven development across three technology stacks. Each subdirectory is a standalone application:

- **DotnetApp/**: .NET/C# application
- **ExpressApp/**: Node.js/Express application
- **GoApp/**: Go application

The repo is licensed under Apache 2.0.

## Architecture

Each app directory is self-contained and independent. When working in a specific app, navigate into its directory — build commands, dependencies, and project files are scoped per application.

## Style guides


## Commands

Commands will vary per application once implemented. General patterns to expect:

### ExpressApp (Node.js)
```bash
npm install          # install dependencies
npm run dev          # start dev server
npm test             # run tests
npm run lint         # lint
```

### DotnetApp (.NET 9 MVC + Tailwind CSS)
```bash
# Run from DotnetApp/DotnetApp/
dotnet build         # build
dotnet run           # run (http://localhost:5xxx)
dotnet test          # run tests

# CSS — run alongside dotnet run
npm run css:watch    # watch & rebuild Tailwind on change
npm run css:build    # one-shot minified build
```

### GoApp (Go)
```bash
go build ./...       # build
go run .             # run
go test ./...        # run tests
go vet ./...         # lint/vet
```

> Update this file with actual commands once each app is initialized.
