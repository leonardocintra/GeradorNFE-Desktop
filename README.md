# Gerador Simples de Nota Fiscal
Esse é um simples gerador de arquivo.txt que é enviado para o WebService da Receita Federal. Feito para aqueles clientes que usavam o antigo sistema da propria Receita Federal que é um lixo!

Pra você que esta isento de muitos impostos, que coloca tudo "zero" nos campos de ICMS, IPI e fica sofrendo tendo que cadastrar todos os dados, esse sistema pode te ajudar a automatizar, pois ele gera apenas um arquivo txt que é enviado para o WS.

## Como usar

### Para contribuir / rodar local

  1. `git clone https://github.com/leonardocintra/GeradorNF-e`
  2. Abrir no Visual Studio 2015+
  3. Clique com o botão direito na Solution e instale os Packages


### Onde esta o banco de dados ?

O banco de dados esta no Heroku. Toda transação desse projeto é Rest.

#### API
- Projeto: [GeradorNf-e-API](https://github.com/leonardocintra/GeradorNf-e-API)
- Endereço: [Heroku GeradorNF-e](https://geradornf-prod.herokuapp.com/)
- Token: por enquanto esta "aberto para todos"


## Changelog
 - `v1.0.1` - Versão que faz transação via API - CRUD Emitente OK
	- Agosto/ 2016
 - `v1.0.0` - Versão que faz transação via API
	- Agosto/ 2016
 - `v0.0.1` - Versão que usava o Banco de Dados SQL Server `.mdf`
    - Junho / 2016

## Contribuição
Gere um Fork / Pull Request :)

## Licence
MIT
