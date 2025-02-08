export interface UserInformations {
  name: string;
  cpf: string;
  rg: string;
  cargo: string;
  email: string;
  telefone: string;
  endereco: Endereco;
}

export interface Endereco {
  cep: string;
  rua: string;
  bairro: string;
  cidade: string;
  numero: number;
}

export interface LoginReq{
  Email: string;
  Password: string;
}