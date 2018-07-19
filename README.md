# Gif In Console

This is a project that I made because I saw a tweet about a gif being played on the command line. [Link to the tweet](https://twitter.com/github/status/1007696362576728064).
This inspired me to try and create such an application myself. 

## Set-up

For the Application to work we need to do 2 things.  
- Build the dotnet application
- Compile the C++ code in a shared library

Make sure that the directory `lib` exists in `GifInConsole`.  
If the directory does not exist, create it by running this command in the `GifInConsole` directory:
```
mkdir lib
```

### Compiling the C++ code

This step requires you to be in the `ImageProcessor` directory.  
In this directory you run these 2 commands: 
```
g++ -fpic -c -O3 src/imgProcessor.cpp
```
and
```
g++  -shared ./imgProcessor.o -o ../GifInConsole/lib/imgProcessor.dll
```
This creates a dll file in the `lib` directory of `GifInConsole`


### Building the dotnet core application

This step is as simple as making sure that you are in the `GifInConsole` Directory.  
There you run `dotnet build -c Release`

This builds the application to `bin/Release` and takes the created C++ library with it.


## Other details

this project is hosted on my [Gitlab](https://gitlab.com/limecta/gif-in-console) and [Github](https://github.com/bryankroesbeek/gif-in-console) :)