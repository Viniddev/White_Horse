export interface retornoLogin {
  message: string;
  sendToken: boolean;
}

export interface Data {
  UserName: string;
  Email: string;
  Token: string;
}

export interface retornoLoginComToken {
  data: Data;
  message: string;
}

