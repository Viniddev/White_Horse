export interface retornoLogin {
  message: string;
  sendToken: boolean;
}

export interface Data {
  userName: string;
  email: string;
  token: string;
}

export interface retornoLoginComToken {
  data: Data;
  message: string;
}

