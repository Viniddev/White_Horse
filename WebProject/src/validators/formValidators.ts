import { UserInformations } from "@/@types/req";

export function validarDadosUsuario(usuario: UserInformations): Record<string, string> {
  const erros: Record<string, string> = {};

  // 1. Validar Nome
  if (!validarNome(usuario.name)) {
    erros.name = "Nome inválido. É necessário nome e sobrenome.";
  }

  // 2. Validar CPF
  if (!validarCPF(usuario.cpf)) {
    erros.cpf = "O CPF informado é inválido.";
  }

  // 3. Validar RG
  if (!validarRG(usuario.rg)) {
    erros.rg = "O RG informado é inválido.";
  }

  // 4. Validar Email
  if (!validarEmail(usuario.email)) {
    erros.email = "O formato do e-mail é inválido.";
  }

  // 5. Validar Telefone
  if (!validarTelefone(usuario.phoneNumber)) {
    erros.phoneNumber = "O telefone deve ter 10 ou 11 dígitos (com DDD).";
  }

  // 6. Validar Senha
  if (!validarSenha(usuario.password)) {
    erros.password = "A senha deve ter no mínimo 8 caracteres.";
  }

  // 7. Validar CEP (parte do endereço)
  if (!validarFormatoCEP(usuario.address.cep)) {
    erros.cep = "O formato do CEP é inválido.";
  }

  // Adicione outras validações obrigatórias, como o número do endereço
  if (!usuario.address.number || usuario.address.number === 0) {
    erros.numeroEndereco = "O número do endereço é obrigatório.";
  }

  return erros;
}

function validarNome(nome: string) {
  // Verifica se o nome não é nulo ou apenas espaços em branco
  if (!nome || nome.trim() === "") {
    return false;
  }

  // Divide o nome em partes e verifica se há pelo menos duas (nome e sobrenome)
  const partesNome = nome.trim().split(/\s+/);
  if (partesNome.length < 2) {
    return false;
  }

  return true;
}

function validarCPF(cpf: string) {
  // Remove caracteres não numéricos
  const cpfLimpo = String(cpf).replace(/[^\d]/g, "");

  // Verifica se o CPF tem 11 dígitos ou se é uma sequência de números iguais
  if (cpfLimpo.length !== 11 || /^(\d)\1{10}$/.test(cpfLimpo)) {
    return false;
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
    return false;
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
    return false;
  }

  return true;
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

  // Verifica se o CEP tem 8 dígitos e se são todos números
  if (/^\d{8}$/.test(cepLimpo)) {
    return true;
  }

  return false;
}

function validarEmail(email: string) {
  // Verifica se o campo não é nulo ou vazio
  if (!email) {
    return false;
  }

  // Expressão regular para validar o formato do e-mail.
  // Checa por: [caracteres]@[caracteres].[caracteres]
  const regex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/;

  // O método .test() da expressão regular retorna true ou false
  return regex.test(String(email).toLowerCase());
}

function validarTelefone(telefone: string) {
  // Remove todos os caracteres não numéricos
  const telefoneLimpo = String(telefone).replace(/\D/g, "");

  // Verifica se o número de dígitos é 10 (fixo) ou 11 (celular)
  return telefoneLimpo.length >= 10 && telefoneLimpo.length <= 11;
}


function validarSenha(senha: string) {
  // Regra simples: verifica se a senha não é nula e tem pelo menos 8 caracteres.
  // Você pode adicionar mais regras aqui (ex: letra maiúscula, número, etc.)
  return senha && senha.length >= 8;
}