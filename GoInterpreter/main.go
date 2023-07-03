package main

import (
	"LotusProgrammingLanguage/repl"
	"fmt"
	"os"
	"os/user"
)

func main() {
	user, err := user.Current()
	if err != nil {
		panic(err)
	}
	fmt.Printf("Hello %s, and welcome to the Lotus Programming Language\n", user.Username)
	repl.Start(os.Stdin, os.Stdout)
}
