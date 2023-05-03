Criar uma API usando .NET Core que seja capaz de manipular as informações de um tipo específico de dados  
denominado “Cliente”.  
O cliente deve possuir possui necessariamente:    
 Nom    
 E-mail  
 Contato (Objeto)  
o E-mail  
o DDD  
o Telefone  
 CPF   
 RG          
 Endereço (Objeto)    
o CEP   
o Logradouro   
o Numero   
o Bairro  
o Complemento  
o Cidade  
o Estado  
o Referencia  

A API deverá usar como base de dados um JSON criado por você.  
Você deve pensar em um formato onde você possa escrever e recuperar esses dados expostos, utilizando todas as  
melhores práticas de desenvolvimento: Orientação a Objeto, SOLID, Injeção de Dependência, Estrutura em Camadas,  
entre outras de seu conhecimento  
Os serviços deverão conter as seguintes funcionalidades:    
 Listar todos os clientes cadastrados  
 Listar todos os clientes cadastrados com filtro de nome e/ou CPF  
 Adicionar Novo Cliente  
 Atualizar Cliente Existente  
 Remover Cliente  
A API deve contemplar as rotas de acesso para as funcionalidades de serviço definidas e os verbos http  
correspondentes.  
 /cliente/listar  
o Criado para atender lista de todos e filtros  
 /cliente/criar  
 /cliente/atualizar/{identificação}  
 /cliente/remover/{identificação}  
