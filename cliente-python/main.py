import tkinter as tk
from pessoas.api import buscar_pessoa_por_id
from pessoas.categorizar import categorizar_idade


def limpar_campos():
    """
    Limpa todos os campos de exibição.
    """
    label_nome.config(text="Nome: ")
    label_idade.config(text="Idade: ")
    label_categoria_idade.config(text="Categoria de Idade: ")
    label_cidade.config(text="Cidade: ")
    label_profissao.config(text="Profissão: ")


def exibir_dados_pessoa(pessoa):
    """
    Exibe os dados da pessoa na mesma janela.
    Se a pessoa não for encontrada, exibe uma mensagem de erro.
    """
    if pessoa is None:
        label_msg.config(text="Pessoa não encontrada!", fg="red")
        limpar_campos()  # Limpa os campos se a pessoa não for encontrada
        return

    idade_categoria = categorizar_idade(pessoa["idade"])

    # Atualiza os rótulos com as informações da pessoa
    label_nome.config(text=f"Nome: {pessoa['nome']}")
    label_idade.config(text=f"Idade: {pessoa['idade']}")
    label_categoria_idade.config(text=f"Categoria de Idade: {idade_categoria}")
    label_cidade.config(text=f"Cidade: {pessoa['cidade']}")
    label_profissao.config(text=f"Profissão: {pessoa['profissao']}")

    # Exibe a mensagem de sucesso
    label_msg.config(text="Dados encontrados com sucesso!", fg="green")

    # Torna os campos visíveis após a busca bem-sucedida
    label_nome.pack(pady=5)
    label_idade.pack(pady=5)
    label_categoria_idade.pack(pady=5)
    label_cidade.pack(pady=5)
    label_profissao.pack(pady=5)


def buscar_e_exibir():
    """
    Função que busca a pessoa pelo ID inserido no campo de entrada
    e exibe os dados na mesma janela.
    """
    id_pessoa = entry_id.get()  # Pega o valor inserido no campo de texto

    try:
        pessoa = buscar_pessoa_por_id(id_pessoa)
        exibir_dados_pessoa(pessoa)
    except Exception as e:
        label_msg.config(text=f"Ocorreu um erro: {e}", fg="red")
        limpar_campos()


def on_validate_input(char):
    """
    Valida a entrada do campo de ID para permitir apenas números.
    """
    return char.isdigit() or char == ""


def main():
    """
    Função principal que executa a interface gráfica.
    """
    # Criar a janela principal
    root = tk.Tk()
    root.title("Consulta de Pessoa")

    # Abrir a janela maximizada
    root.state("zoomed")

    # Rótulo para o campo de entrada de ID
    label_instrucoes = tk.Label(root, text="Digite o ID da pessoa:", font=("Arial", 14))
    label_instrucoes.pack(pady=20)

    # Validação para aceitar apenas números no campo de ID
    validate_input = root.register(on_validate_input)

    # Campo de entrada para o ID da pessoa (somente números)
    global entry_id
    entry_id = tk.Entry(
        root, font=("Arial", 14), validate="key", validatecommand=(validate_input, "%S")
    )
    entry_id.pack(pady=10)

    # Botão para buscar a pessoa
    button_buscar = tk.Button(
        root, text="Buscar", command=buscar_e_exibir, font=("Arial", 14)
    )
    button_buscar.pack(pady=20)

    # Label para a mensagem de status ou erro
    global label_msg
    label_msg = tk.Label(
        root, text="Digite o ID da pessoa acima", fg="blue", font=("Arial", 12)
    )
    label_msg.pack(pady=10)

    # Labels para exibir os dados da pessoa (inicialmente ocultos)
    global label_nome, label_idade, label_categoria_idade, label_cidade, label_profissao
    label_nome = tk.Label(root, text="Nome: ", font=("Arial", 14))

    label_idade = tk.Label(root, text="Idade: ", font=("Arial", 14))

    label_categoria_idade = tk.Label(
        root, text="Categoria de Idade: ", font=("Arial", 14)
    )

    label_cidade = tk.Label(root, text="Cidade: ", font=("Arial", 14))

    label_profissao = tk.Label(root, text="Profissão: ", font=("Arial", 14))

    # Iniciar o loop da interface gráfica
    root.mainloop()


if __name__ == "__main__":
    main()
