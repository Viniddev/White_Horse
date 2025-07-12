export interface UserInformations {
  id: string;
  name: string;
  cpf: string;
  rg: string;
  role: string;
  email: string;
  phoneNumber: string;
  creationDate: string;
  password: string;
  address: Endereco;
}

export interface UpdateUserInformations {
  id: string;
  role: string;
  email: string;
  phoneNumber: string;
  address: Endereco;
}

export interface Endereco {
  id: string;
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