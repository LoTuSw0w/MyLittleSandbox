package token

type TokenType string

var keywords = map[string]TokenType{
	"fn":     FUNCTION,
	"let":    LET,
	"true":   TRUE,
	"false":  FALSE,
	"if":     IF,
	"else":   ELSE,
	"return": RETURN,
	//type

}

func LookupIndent(indent string) TokenType {
	if tok, ok := keywords[indent]; ok {
		return tok
	}
	return IDENT
}

type Token struct {
	Type    TokenType
	Literal string
}

const (
	ILLEGAL = "ILLEGAL"
	EOF     = "EOF"

	// Identifiers + literals
	IDENT = "IDENT"
	INT   = "INT"

	//Operators
	ASSIGN          = "="
	PLUS            = "+"
	INCREMENT_PLUS  = "++"
	DECREMENT_MINUS = "--"
	MINUS           = "-"
	BANG            = "!"
	ASTERISK        = "*"
	SLASH           = "/"
	LT              = "<"
	GT              = ">"
	EQ              = "=="
	NOT_EQ          = "!="
	PLUS_SC         = "+="
	MINUS_SC        = "-="

	//Delimiters
	COMMA     = ","
	SEMICOLON = ";"
	LPAREN    = "("
	RPAREN    = ")"
	LBRACE    = "{"
	RBRACE    = "}"

	//Keywords
	FUNCTION = "FUNCTION"
	LET      = "LET"
	TRUE     = "TRUE"
	FALSE    = "FALSE"
	IF       = "IF"
	ELSE     = "ELSE"
	RETURN   = "RETURN"
)
