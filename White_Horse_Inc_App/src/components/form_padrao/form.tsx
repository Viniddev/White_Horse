import React from "react";
import InputTypeText from "../inputs/input_type_text";
import { Button } from "primereact/button";
import { UserInformations } from "@/@types/req";
import { EMPTY_USER } from "@/utils/constants/consts";
import InputTypeNumber from "../inputs/input_type_number";
import InputTypeMask from "../inputs/input_type_mask";
import { BuildDefaultForm } from "@/@types/components";

export default function FormPadrao({ IsRegister }: BuildDefaultForm) {
  const [userInformations, setUserInformations] =
    React.useState<UserInformations>(EMPTY_USER);

  return (
    <div>
      <div className="formgrid grid">
        {IsRegister ? (
          <>
            <div className="field col-12 lg:col-6">
              <InputTypeText
                state={userInformations.name}
                setState={(newValue) =>
                  setUserInformations((prevState) => ({
                    ...prevState,
                    name: newValue,
                  }))
                }
                label={"Nome"}
              />
            </div>
            <div className="field col-12 lg:col-6">
              <InputTypeMask
                state={userInformations.cpf}
                setState={(newValue) =>
                  setUserInformations((prevState) => ({
                    ...prevState,
                    cpf: newValue,
                  }))
                }
                mask="999.999.999-99"
                label={"Cpf"}
              />
            </div>
            <div className="field col-12 lg:col-6">
              <InputTypeMask
                state={userInformations.rg}
                setState={(newValue) =>
                  setUserInformations((prevState) => ({
                    ...prevState,
                    rg: newValue,
                  }))
                }
                mask="99.999.999"
                label={"Rg"}
              />
            </div>
            <div className="field col-12 lg:col-6">
              <InputTypeText
                state={userInformations.cargo}
                setState={(newValue) =>
                  setUserInformations((prevState) => ({
                    ...prevState,
                    cargo: newValue,
                  }))
                }
                label={"Cargo"}
              />
            </div>
          </>
        ) : (
          ""
        )}
        <div className="field col-12 lg:col-6">
          <InputTypeText
            state={userInformations.email}
            setState={(newValue) =>
              setUserInformations((prevState) => ({
                ...prevState,
                email: newValue,
              }))
            }
            label={"E-mail"}
          />
        </div>
        <div className="field col-12 lg:col-6">
          <InputTypeMask
            state={userInformations.telefone}
            setState={(newValue) =>
              setUserInformations((prevState) => ({
                ...prevState,
                telefone: newValue,
              }))
            }
            mask="(99) 99999-9999"
            label={"Telefone"}
          />
        </div>
        <div className="field col-12 lg:col-6">
          <InputTypeMask
            state={userInformations.endereco.cep}
            setState={(newValue: string) =>
              setUserInformations((prevState) => ({
                ...prevState,
                endereco: {
                  ...prevState.endereco,
                  cep: newValue,
                },
              }))
            }
            mask="99999-999"
            label={"Cep"}
          />
        </div>
        <div className="field col-12 lg:col-6">
          <InputTypeText
            state={userInformations.endereco.rua}
            setState={(newValue: string) =>
              setUserInformations((prevState) => ({
                ...prevState,
                endereco: {
                  ...prevState.endereco,
                  rua: newValue,
                },
              }))
            }
            label={"Rua"}
          />
        </div>

        <div className="field col-12 lg:col-6">
          <InputTypeText
            state={userInformations.endereco.bairro}
            setState={(newValue: string) =>
              setUserInformations((prevState) => ({
                ...prevState,
                endereco: {
                  ...prevState.endereco,
                  bairro: newValue,
                },
              }))
            }
            label={"Bairro"}
          />
        </div>
        <div className="field col-12 lg:col-6">
          <InputTypeNumber
            state={userInformations.endereco.numero}
            setState={(newValue: number) =>
              setUserInformations((prevState) => ({
                ...prevState,
                endereco: {
                  ...prevState.endereco,
                  numero: newValue,
                },
              }))
            }
            label={"Número"}
          />
        </div>

        <div className="field col-12 lg:col-6">
          <InputTypeText
            state={userInformations.endereco.cidade}
            setState={(newValue: string) =>
              setUserInformations((prevState) => ({
                ...prevState,
                endereco: {
                  ...prevState.endereco,
                  cidade: newValue,
                },
              }))
            }
            label={"Cidade"}
          />
        </div>

        <div className="field col-12">
          <div className="sessaoBotaoSalvar">
            <Button
              label="Atualizar"
              severity="danger"
              type="button"
              onClick={() => console.log(userInformations)}
            />
          </div>
        </div>
      </div>
    </div>
  );
}
