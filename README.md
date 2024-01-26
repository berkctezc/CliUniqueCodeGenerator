# Build

`
dotnet publish --configuration Release
`

# Run
- locate output dll and

`
dotnet UniqueCodeGenerator.dll --charset ACDEFGHKLMNPRTXYZ234579 --length 8
`

### TODO: 
* add non verbose mode to use output in bash scripts?
