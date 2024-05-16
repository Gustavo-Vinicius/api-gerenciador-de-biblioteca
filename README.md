## 💻 API GENRENCIAMENTO DE BIBLIOTECA

A API de Gerenciamento de Biblioteca oferece uma plataforma robusta para a gestão eficiente de bibliotecas, permitindo que bibliotecários e usuários realizem uma variedade de operações relacionadas aos livros, usuários e empréstimos. Com esta API, os desenvolvedores podem criar aplicativos modernos e interativos para bibliotecas, facilitando o acesso aos recursos bibliográficos e melhorando a experiência do usuário.

## 📫  Routes

### Usuario Controller

<img src="https://img.shields.io/badge/-GET-%2361AFFE" height="30" />

**"/api/Usuario/{Id}"**

_Obter usuarios por id_

**query params:**

`id: int`

**response:**
```
[
  {
    "id": int,
    "nome": string,
    "email": string
  }
]
```

<hr>

<img src="https://img.shields.io/badge/-POST-%2349CC90" height="30" />

**"/api/Usuario"**

_Adicionar novo Usuario_

**body:**
```
{
    {
        "id": int,
        "nome": string,
        "email": string
    }
}
```
<hr>

### Emprestimo Controller

<img src="https://img.shields.io/badge/-POST-%2349CC90" height="30" />

**"/api/Emprestimo"**

**body:**
```
{
  "idUsuario": int,
  "idLivro": int,
  "dataEmprestimo": DateTime,
  "dataDevolucao": DateTime
}
```

**response:**
_No content_

<hr>

<img src="https://img.shields.io/badge/-GET-%2361AFFE" height="30" />

**"/api/Emprestimo"**

_Obtém todos os emprestimos da biblioteca_

**response:**
```
{
  "idUsuario": int,
  "idLivro": int,
  "dataEmprestimo": DateTime,
  "dataDevolucao": DateTime
}
```

<hr>

<img src="https://img.shields.io/badge/-PUT-%23FCA130" height="30" />

**"/api/Emprestimo/{Id}/Devolver"**

_Realiza a devolução do livro_

**response:**
_No content_

<hr>

### Livro Controller

<img src="https://img.shields.io/badge/-GET-%2361AFFE" height="30" />

**"/api/Livro"**

_Obtém todos os livros_

**response:**
```
[
  {
    "id": int,
    "titulo": string,
    "autor": string,
    "isbn": string,
    "anoPublicacao": int
  }
]
```

<hr>

<img src="https://img.shields.io/badge/-POST-%2349CC90" height="30" />

**"/api/Livro"**

_Cadastra um novo livro na biblioteca_

**body:**
```
  {
    "id": int,
    "titulo": string,
    "autor": string,
    "isbn": string,
    "anoPublicacao": int
  }
```
**response:**
_No content_

<hr>

<img src="https://img.shields.io/badge/-GET-%2361AFFE" height="30" />

**"/api/Livro/{Id}"**

_Obter livro pelo Id_

**route params:**

`id: int`

**response:**
```
  {
    "id": int,
    "titulo": string,
    "autor": string,
    "isbn": string,
    "anoPublicacao": int
  }
```

<hr>

<img src="https://img.shields.io/badge/-DELETE-%23F93E3E" height="30" />

**"/api/Livro/{Id}"**

_Deletar livro pelo Id_

**route params:**

`id: int`

**response:**
_No content_

<hr>