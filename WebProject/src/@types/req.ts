export interface UserInformations {
  id: number;
  name: string;
  cpf: string;
  rg: string;
  role: string;
  email: string;
  phoneNumber: string;
  creationDate: string;
  address: Endereco;
}

export interface UpdateUserInformations {
  id: number;
  role: string;
  email: string;
  phoneNumber: string;
  address: Endereco;
}

export interface Endereco {
  id: number;
  creationDate: string;
  cep: string;
  street: string;
  neighborhood: string;
  city: string;
  number: number;
}

export interface LoginReq{
  Email: string;
  Password: string;
}