# Aplicações Distribuídas - Autenticação do sistema e cruds de cadastro de usuários
<p align="center">
<img src="http://img.shields.io/static/v1?label=STATUS&message=EM%20DESENVOLVIMENTO&color=GREEN&style=for-the-badge"/>
</p>

<p align="center">
<img src="https://wiki.opasuite.com.br/images/thumb/f/f8/Download_%283%29.png/300px-Download_%283%29.png"/>
</p>


**Aplicações Distribuídas - Autenticação do sistemas e cruds de cadastro de usuários [Aplicações Distribuidas]**

**Integrantes:** Davi Costa, Endy Keveen Menezes, Guilherme Neves, Victor Rocha

**Introdução**

**Problema**

Atualmente a instituição não tem um sistema efetivo de login e cadastro de usuários (professores, alunos e administradores) de forma que possam monitorar e organizar permissões de seus sistemas

**Objetivos**

O objetivo do projeto é desenvolver um sistema de cadastro de usuários [CRUD], como também de autenticação do sistemas.

**Objetivos específicos**

Desenvolver tela de login(usuário e senha); [Front-End e Back-End]

Desenvolver tela de cadastro com dados pertinentes a serem inseridos; [Front-End e Back-End]

**Justificativa**

Diante da dificuldade da organização e do gerenciamento dos sistemas da instituição, viu-se necessário a criação de um sistema de forma que facilitará esse gerenciamento

**Público-Alvo**

Instituição de ensino - > Alunos da instuição em aprendizagem

**Especificações do Projeto**

**Personas**

- Jonas Silveira tem 21 anos e precisa do seu cadastro no sistema da instituição para realizar seus estudos.

- Renato Braga tem 25 anos e é professor. Ele precisa do seu acesso ao sistema da instituição para aplicar uma prova.

- Arthur Francisco tem 28 anos e precisa de uma conta admin na instituição para realizar o cadastro de um professor.

- Marcos Silva tem 18 anos e acaba de entrar na faculdade, necessitando de um cadastro no sistema da instituição.

**Histórias de Usuários**

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

|EU COMO... `PERSONA`  | QUERO/PRECISO ... `FUNCIONALIDADE`                                                                     |PARA ... `MOTIVO/VALOR`                 |
|--------------------- |--------------------------------------------------------------------------------------------------------|----------------------------------------|
| Usuário do sistema  1|Realizar o cadastro de aluno no sistema                                       | Realizar seus estudos |
| Usuário do sistema  2|Acessar seu cadastro de professor                                                | Aplicar uma prova|
| Usuário do sistema  3|Ter uma conta admin na instituição                                  | Realizar o cadastro de novos professores|
| Usuário do sistema  4|Ter um cadastro de aluno no sistema                                                              | Acessar o Quiz do sistema |
 
**Requisitos**

**Requisitos Funcionais**

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-001| Permitir o cadastro do aluno | ALTA | 
|RF-002| O acesso será feito através de login | ALTA |
|RF-003| Permitir o cadastro de professores pelo admin | MÉDIA |
|RF-004| Permitir a adição de matérias | MÉDIA |
|RF-005| Permitir a diferenciação de um cadastro de aluno, professor e admin | ALTA |
|RF-006| Permitir que o usuário edite suas informações | BAIXA |
|RF-007| Permitir que o usuário admin edite informações dos cadastros | BAIXA |

**Requisitos não Funcionais**

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-001| Ter uma internet estável para acessar a página | ALTA | 
|RNF-002| A página deve ser responsiva |  ALTA | 
|RNF-003| A página deve armazenar as informações em um banco de dados |  ALTA |  
|RNF-004| A página seguirá as premissas da LGPD |  MÉDIA |  
|RNF-005| Senhas serão protegidas com criptografia |  MÉDIA | 

**Metodologia**

**Gerenciamento do Projeto**

Para acompanhar e controlar os processos e a execução das atividades, iremos trabalhar com o Azure DevOps, através dessa plataforma poderemos criar cards de tarefas a serem realizadas, acompanhar o progresso de cada uma delas, e discutir impedimentos.

 Com o acompanhamento correto as demandas têm muito mais chances de serem concluídas com êxito, evitando surpresas e atrasos na sua implementação **.**

**Planejamento e Divisão de Papéis**

Para nosso projeto, dividimos os integrantes em algumas funções, sendo cada um responsável pelas entregas em determinada área do projeto e acompanhamento na evolução do mesmo **.**

A distribuição ficou da seguinte maneira:

- **Gerente de Projeto** :  Renato Nunes
- **Arquiteto de software:**  Davi Silva
- **Desenvolvedor Back-end:**  Victor Rocha
- **Desenvolvedor Front-end:** Guilherme Neves
- **Desenvolvedor Mobile:** Endy Custodio


