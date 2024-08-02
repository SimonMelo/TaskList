# API de Lista de Tarefas

Esta API permite gerenciar uma lista de tarefas. É possível criar, listar, atualizar e excluir tarefas.

## Endpoints

### 1. Listar Todas as Tarefas

- **URL**: `/api/task`
- **Método**: `GET`
- **Descrição**: Recupera todas as tarefas.

### 2. Obter Tarefa por ID

- **URL**: `/api/task/{id}`
- **Método**: `GET`
- **Parâmetros**: 
  - `id` (Path) - O ID da tarefa que deseja recuperar.
- **Descrição**: Recupera uma tarefa específica pelo ID.

### 3. Criar Nova Tarefa

- **URL**: `/api/task`
- **Método**: `POST`
- **Descrição**: Adiciona uma nova tarefa.
- **Body**:
  - `Title` (string) - Título da tarefa (obrigatório).
  - `Description` (string, opcional) - Descrição da tarefa.
  - `IsCompleted` (bool) - Indica se a tarefa está completa (padrão: `false`).
- **Resposta de Sucesso**:
  - **Status Code**: `201 Created`
  - **Cabeçalho**: `Location` - URL da nova tarefa criada.

### 4. Atualizar Tarefa Existente

- **URL**: `/api/task/{id}`
- **Método**: `PUT`
- **Parâmetros**: 
  - `id` (Path) - O ID da tarefa que deseja atualizar.
- **Descrição**: Atualiza os detalhes de uma tarefa existente.
- **Body**:
  - `Title` (string) - Título da tarefa.
  - `Description` (string, opcional) - Descrição da tarefa.
  - `IsCompleted` (bool) - Indica se a tarefa está completa.

- **Resposta de Sucesso**:
  - **Status Code**: `204 No Content`

### 5. Excluir Tarefa

- **URL**: `/api/task/{id}`
- **Método**: `DELETE`
- **Parâmetros**: 
  - `id` (Path) - O ID da tarefa que deseja excluir.
- **Descrição**: Remove uma tarefa específica pelo ID.
- **Resposta de Sucesso**:
  - **Status Code**: `204 No Content`

## Modelos

### ToDoItem

- **Id** (long) - Identificador único da tarefa.
- **Title** (string) - Título da tarefa (obrigatório, não pode conter mais de 50 caracteres).
- **Description** (string, opcional) - Descrição da tarefa (não pode conter mais de 50 caracteres).
- **IsCompleted** (bool) - Indica se a tarefa está completa (padrão: `false`).

## Validações

- O `Title` e `Description` são limpos para remover espaços em branco do início e do fim antes de salvar.
- `Title` é obrigatório e deve ter no máximo 50 caracteres.
- `Description`, se fornecido, deve ter no máximo 50 caracteres.
- `IsCompleted` é obrigatório e é um booleano.
