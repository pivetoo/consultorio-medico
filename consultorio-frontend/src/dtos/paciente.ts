export interface Paciente {
    id: number;
    nome: string;
    cpf: string;
    datanascimento: string | Date;
    telefone: string;
    email: string;
    cep: string;
    cidade: string;
    rua: string;
    bairro: string;
    numero: string;
}