# IoC and Composition - Activity 1

The application accepts commands/queries using a simple command-line DSL:

```
add Espresso ESP
add Latte LAT
lookup ESP
# -> Name: Espresso
```

All of the components that make up the application are configured manually in
_Program.cs_.

### Activity

 1. Create an Autofac container
 2. Restructure the program so that `CommandLineCatalogApi` is resolved from
    the Autofac container
 3. Register the application components so that the program runs as before

