export interface Medico {
    id: number;
    nome: string;
    crm: string;
    especialidade: EspecialidadeMedica;
    telefone: string;
    email: string;
}

enum EspecialidadeMedica {
    Cardiologista = 1,
    Dermatologista = 2,
    Neurologista = 3,
    Ortopedista = 4
}