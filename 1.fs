// Type inference
let a = 10

// Assignment - mutability is declared explicitly
let mutable b = 10
b <- 15

// Collections are immutable
let items = [1..5]
List.append items [6]
items

// Defining functions
// Uses currying: prefix takes a string which returns a function which takes a string which returns a string.
let prefix prefixString baseString =
    prefixString + ", " + baseString

prefix "hello" "world"

// Pipeline operator: build a chain of functions operating on a collection/value
let names = ["Sebastian"; "Atef"; "Abizar"]

names
|> Seq.map (prefix "Hello") // Partial application

let prefixWithHello = prefix "Hello"
let exclaim s =
    s + "!"

names
|> Seq.map prefixWithHello
|> Seq.map exclaim
|> Seq.sort

// Function composition (composition operator - direction matters)
let bigHello = prefixWithHello >> exclaim
names
|> Seq.map bigHello
|> Seq.sort

// Seqs are lazily evaluated. Use Seq.iter to eval immediately.