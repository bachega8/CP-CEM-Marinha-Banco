# CP-CEM-Marinha-Banco
Banco de Questões para auxiliar nos estudos para o concurso público dos engenheiros da marinha.

Banco de dados criado em ACESS e sistema de gerenciamento das questões em VB.net para auxiliar no controle
dos estudos para o concurso público. O sistema é capaz também de gerar provas em PDF de forma randômica com
base na quantidade e tipos de questões que o usuário escolher.

## Instalação

Baixe os arquivos de instalção e o banco em ACESS contidos no link:
https://github.com/bachega8/CP-CEM-Marinha-Banco/releases/tag/v1.1.0

Siga as seguintes instruções após a instalação para a correta ligação do sistema com o banco de dados:
```
Junto com a pasta de instalação do software você recebe o banco de dados da aplicação : DB_PROVAS_VS1.accdb
é neste banco ,em ACESS, que estão todas as informações necessárias para execução do software.
Você deve indicar ao sistema o local desse banco de dados. Isso é feito da seguinte maneira:

1. Abra o arquivo "BD_QUESTOES_MARINHA.exe.config" utilizando algum editor de texto, como o bloco de notas

2. Nas últimas linhas desse arquivo, na seção <ConnectionStrings> você encontra a Informação "DataSource"
que indica o local em que se encontra o banco de dados. Ao acabar de instalar, por padrão, vem o seguinte
nome:

"C:\Users\Matheus\Documents\Concursos\Marinha\BANCO\DB_PROVAS_VS1.accdb"

Você deve alterar este nome com o local onde o banco de dados se encontra em seu computador.

Exemplo: se o seu banco de dados está em uma pasta chamada DADOS em C:, então você deverá alterar para
"C:\DADOS\DB_PROVAS_VS1.accdb"

3. Ao salvar, é bem provável que o computador o forçará para salvar como uma cópia. Neste caso, basta apenas
substituir o arquivo original (BD_QUESTOES_MARINHA.exe.config) pelo seu arquivo atualizado. 

4. Abra o software e o execute normalmente. 

```


## Tela Principal
![telaPrincipal](https://user-images.githubusercontent.com/50142743/87493246-be2c8d80-c622-11ea-95de-44d8a6864395.png)

## Criando um Assunto Novo
Você pode criar um assunto novo clicando F3 ou a partir do menu principal superior.

![novoAssunto](https://user-images.githubusercontent.com/50142743/87493554-63dffc80-c623-11ea-98a7-61a4dbb275e7.png)

A adição de Temas novos segue o mesmo procedimento.

## Cadastrando Questões
As questões são cadastradas por imagem, logo, voce precisa "printar" a imagem da questão do concurso e salvá-la em sua máquina.
O gabarito pode ser composto por texto inserido ou também alguma outra imagem. Você pode cadastrar uma questão apertando F1

![questao](https://user-images.githubusercontent.com/50142743/87493878-1e6fff00-c624-11ea-8e48-60ab9f602f96.png)

## Gerando Provas PDF
Você pode construir a prova que deseja escolhendo ANO - TEMA - ASSUNTO - QUANTIDADE DE QUESTÕES de múltiplas linhas conforma
mostra a imagem abaixo

![Prova](https://user-images.githubusercontent.com/50142743/87494173-bb329c80-c624-11ea-82ff-318e7d7d153e.png)

Também pode deixar em aberto para o sistema escolher a quantidade especificada de qualquer ano, assunto ou tema. Basta
selecinar a opção 'selecionar todos' dos comboBox.

## Prova Final 
A prova gerada terá o aspecto conforme mostra a imagem a seguir.

![Prova2](https://user-images.githubusercontent.com/50142743/87494441-63486580-c625-11ea-8b3f-9e23734fbb69.png)
