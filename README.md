# Problema
Dada uma matriz binária 2D de tamanho MxN preenchida com '0' (zero) e '1' (um),
encontre o retângulo de maior área contendo apenas '1' e retorne o valor de sua área.
Exemplo:

Entrada:

[

  ['1','0','1','0','0'],  
  ['1','0','1','1','1'],  
  ['1','1','1','1','1'],  
  ['1','0','0','1','0']  
]

Saída: 6

# Solução

Criada uma solução em DotNet core 2.2 do tipo console para validar 
dados de entrada e informar o maior valor de retangulo encontrado.

# Testes

Criado o projeto de testes utilizando XUnit.

Foram validados três tipos de entradas

# 1 - Matriz 4x5

entrada = new int[4, 5]
             {
                  {1,0,1,0,0},
                  {1,0,1,1,1},
                  {1,1,1,1,1},
                  {1,0,0,1,0}
             };
             
Saída: 6             

# 2 - Matriz 8x5

entrada = new int[8, 5]
             {
                  {1,0,1,0,0},
                  {1,0,0,1,1},
                  {1,0,0,1,1},
                  {1,0,0,1,0},
                  {1,0,1,0,0},
                  {1,0,1,1,1},
                  {1,1,1,1,1},
                  {1,0,0,1,0}
             };
             
Saída: 6 

# 3 - Matriz 2x5

entrada = new int[2, 5]
             {
                  {1,0,1,0,0},
                  {1,0,1,1,1} 
             };

Saída: Nenhum retângulo válido.

# Conslusão

O programa recebe a entrada no formato de matriz,
semelhante ao exemplo informado no ínicio do documento.

Deve-se percorrer todas as linhas da matriz, validando se existe sequência válida(A1). 

Foi utilizado recursividade ao encontrar uma linha válida e executado 
o mesmo processo de validação em todas as linhas posteriores,
o intuíto é encontrar o retângulo e calcular sua área(A1).

# A1 - Sequencia válida

Para formar um retângulo válido, linhas e colunas não podem ter o mesmo valor,
no ínicio do documento foi demonstrado o valor 6 como saída válida, 
constiuíndo 2 linhas x 3 colunas.

