import { IValidFields } from "@/@types/IValidFields";
import { UserInformations } from "@/@types/req";
import { VALID_FIELDS_EMPTY } from "@/utils/constants/consts";

export function validarDadosUsuario(usuario: UserInformations): IValidFields {
  const erros: IValidFields = VALID_FIELDS_EMPTY;

  // 1. Validar Nome
  erros.name = validarNome(usuario.name);

  // 2. Validar CPF
  erros.cpf = validarCPF(usuario.cpf);

  // 3. Validar RG
  erros.rg = validarRG(usuario.rg);

  // 4. Validar Email
  erros.email = validarEmail(usuario.email);

  // 5. Validar Telefone
  erros.phoneNumber = validarTelefone(usuario.phoneNumber);

  // 6. Validar Senha
  erros.password = validarSenha(usuario.password);

  // 7. Validar CEP (parte do endereço)
  erros.cep = validarFormatoCEP(usuario.address.cep);

  // 8. Validar Numero do endereco é inválido
  erros.numeroEndereco = (usuario.address.number === null || usuario.address.number === 0);

  // 9. Validar Cargo Usuário é inválido
  erros.role = (usuario.role === null || typeof usuario.role !== "string");

  return erros;
}

function validarNome(nome: string) {
  // Verifica se o nome não é nulo ou apenas espaços em branco
  if (!nome || nome.trim() === "") {
    return true;
  }

  // Divide o nome em partes e verifica se há pelo menos duas (nome e sobrenome)
  const partesNome = nome.trim().split(/\s+/);
  if (partesNome.length < 2) {
    return true;
  }

  return false;
}

function validarCPF(cpf: string) {
  // Remove caracteres não numéricos
  const cpfLimpo = String(cpf).replace(/[^\d]/g, "");

  // Verifica se o CPF tem 11 dígitos ou se é uma sequência de números iguais
  if (cpfLimpo.length !== 11 || /^(\d)\1{10}$/.test(cpfLimpo)) {
    return true;
  }

  let soma = 0;
  let resto;

  // Validação do primeiro dígito verificador
  for (let i = 1; i <= 9; i++) {
    soma += parseInt(cpfLimpo.substring(i - 1, i)) * (11 - i);
  }
  resto = (soma * 10) % 11;
  if (resto === 10 || resto === 11) {
    resto = 0;
  }
  if (resto !== parseInt(cpfLimpo.substring(9, 10))) {
    return true;
  }

  // Validação do segundo dígito verificador
  soma = 0;
  for (let i = 1; i <= 10; i++) {
    soma += parseInt(cpfLimpo.substring(i - 1, i)) * (12 - i);
  }
  resto = (soma * 10) % 11;
  if (resto === 10 || resto === 11) {
    resto = 0;
  }
  if (resto !== parseInt(cpfLimpo.substring(10, 11))) {
    return true;
  }

  return false;
}

function validarRG(rg: string) {
  // Remove caracteres não numéricos (pontos, traços)
  const rgLimpo = String(rg).replace(/[^\d]/g, "");

  // Verifica se o RG não está vazio e tem um comprimento comum (entre 7 e 9 dígitos)
  if (rgLimpo.length >= 7 && rgLimpo.length <= 9) {
    return true;
  }

  return false;
}

function validarFormatoCEP(cep: string) {
  // Remove o traço
  const cepLimpo = String(cep).replace("-", "");

  return !/^\d{8}$/.test(cepLimpo); // true se for inválido
}

function validarEmail(email: string) {
  // Verifica se o campo não é nulo ou vazio
  if (!email) {
    return true;
  }

  // Expressão regular para validar o formato do e-mail.
  // Checa por: [caracteres]@[caracteres].[caracteres]
  const regex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/;

  // O método .test() da expressão regular retorna true ou false
  return !regex.test(String(email).toLowerCase());
}

function validarTelefone(telefone: string) {
  // Remove todos os caracteres não numéricos
  const telefoneLimpo = String(telefone).replace(/\D/g, "");

  // Verifica se o número de dígitos é 10 (fixo) ou 11 (celular)
  return !(telefoneLimpo.length >= 10 && telefoneLimpo.length <= 11);
}


function validarSenha(senha: string | null): boolean {
  // Regra simples: verifica se a senha não é nula e tem pelo menos 8 caracteres.
  // Você pode adicionar mais regras aqui (ex: letra maiúscula, número, etc.)
  if (typeof senha !== "string") 
    return false;

  return senha.length >= 8;
}