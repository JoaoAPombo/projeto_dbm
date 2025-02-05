import requests


def buscar_pessoa_por_id(id):
    """
    Busca uma pessoa pelo ID através da API.

    :param id: ID da pessoa
    :return: Dados da pessoa em formato JSON ou None em caso de erro
    """
    url = f"http://localhost:5268/api/Pessoas/{id}"  # URL para a sua API
    response = requests.get(url)

    if response.status_code == 200:
        return response.json()  # Retorna os dados como um dicionário
    else:
        print(f"Erro ao buscar pessoa: {response.status_code}")
        return None
