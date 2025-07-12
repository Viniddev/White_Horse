import { IPostRequest } from "@/@types/IPostRequest";
import { IValidFields } from "@/@types/IValidFields";
import { UserInformations } from "@/@types/req";

export const EMPTY_USER: UserInformations = {
  id: '',
  creationDate: "",
  name: "",
  cpf: "",
  rg: "",
  role: "",
  email: "",
  phoneNumber: "",
  password: "",
  address: {
    id: '',
    creationDate: "",
    cep: "",
    street: "",
    neighborhood: "",
    city: "",
    number: 0,
  },
};

export const EMPTY_FILTRO_FORMULARIO_PRINCIPAL = {
  preco: 0,
  nome: "",
  topico: { name: "", code: 0 },
};

export const EMPTY_POST: IPostRequest = {
  topic: '',
  content: '',
  creatorId: ''
}

export const VALID_FIELDS_EMPTY: IValidFields = {
  name: false,
  cpf: false,
  rg: false,
  email: false,
  phoneNumber: false,
  password: false,
  cep: false,
  numeroEndereco: false,
  role: false
};