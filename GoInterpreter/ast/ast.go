package ast

import (
	"LotusProgrammingLanguage/token"
)

type Node interface {
	TokenLiteral() string
}

type Statement interface {
	Node
	statementNode()
}

type Expression interface {
	Node
	expressionNode()
}

type Program struct {
	Statements []Statement
}

type LetStatement struct {
	Token token.Token // LET token
	Name  *Identifiers
	Value Expression
}

func (ls *LetStatement) statementNode()       {}
func (ls *LetStatement) TokenLiteral() string { return ls.Token.Literal }

type Identifiers struct {
	Token token.Token // IDENT token
	Value string
}

func (i *Identifiers) expressionNode()      {}
func (i *Identifiers) TokenLiteral() string { return i.Token.Literal }

func (p *Program) TokenLiteral() string {
	if len(p.Statements) > 0 {
		return p.Statements[0].TokenLiteral()
	} else {
		return ""
	}
}
