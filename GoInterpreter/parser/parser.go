package parser

import (
	"LotusProgrammingLanguage/lexer"
	"LotusProgrammingLanguage/token"
)

type Parser struct {
	l         *lexer.Lexer
	curToken  token.Token
	peekToken token.Token
}
