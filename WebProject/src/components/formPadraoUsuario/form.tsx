import React from "react";
import InputTypeText from "../inputs/inputTypeText";
import { Button } from "primereact/button";
import InputTypeNumber from "../inputs/inputTypeNumber";
import InputTypeMask from "../inputs/inputTypeMask";
import { BuildDefaultForm } from "@/@types/components";
import InputCep from "../inputs/inputCep";
import UseFormPadrao from "@/hooks/useFormPadrao";
import InputTypePassword from "../inputs/inputTypePassword";

import "./formStyles.scss";

export default function FormPadrao({
  IsRegister,
  DefaultUserInformations,
  SetUserState,
}: BuildDefaultForm) {
  
  var { userInformations, IsInvalid } = UseFormPadrao(DefaultUserInformations);

  return (
    <div>
      <div className="formgrid grid">
        {IsRegister ? (
          <>
            <div className="field col-12 lg:col-6">
              <InputTypeText
                state={userInformations.name}
                setState={(newValue) =>
                  SetUserState((prevState) => ({
                    ...prevState,
                    name: newValue,
                  }))
                }
                label={"Nome"}
                required={IsRegister}
                invalid={IsInvalid.name}
              />
            </div>
            <div className="field col-12 lg:col-6">
              <InputTypeMask
                state={userInformations.cpf}
                setState={(newValue) =>
                  SetUserState((prevState) => ({
                    ...prevState,
                    cpf: newValue,
                  }))
                }
                mask="999.999.999-99"
                label={"Cpf"}
                required={IsRegister}
                invalid={IsInvalid.cpf}
              />
            </div>
            <div className="field col-12 lg:col-6">
              <InputTypeMask
                state={userInformations.rg}
                setState={(newValue) =>
                  SetUserState((prevState) => ({
                    ...prevState,
                    rg: newValue,
                  }))
                }
                mask="99.999.999"
                label={"Rg"}
                required={IsRegister}
                invalid={IsInvalid.rg}
              />
            </div>
            {!IsRegister ? (
              <div className="field col-12 lg:col-6">
                <InputTypeText
                  state={userInformations.role}
                  setState={(newValue) =>
                    SetUserState((prevState) => ({
                      ...prevState,
                      role: newValue,
                    }))
                  }
                  label={"Cargo"}
                  required={!IsRegister}
                  invalid={IsInvalid.role}
                />
              </div>
            ) : (
              ""
            )}
          </>
        ) : (
          ""
        )}
        <div className="field col-12 lg:col-6">
          <InputTypeText
            state={userInformations.email}
            setState={(newValue) =>
              SetUserState((prevState) => ({
                ...prevState,
                email: newValue,
              }))
            }
            label={"E-mail"}
            required={true}
            invalid={IsInvalid.email}
          />
        </div>
        <div className="field col-12 lg:col-6">
          <InputTypeMask
            state={userInformations.phoneNumber}
            setState={(newValue) =>
              SetUserState((prevState) => ({
                ...prevState,
                phoneNumber: newValue,
              }))
            }
            mask="(99) 99999-9999"
            label={"Telefone"}
            required={true}
            invalid={IsInvalid.phoneNumber}
          />
        </div>

        {IsRegister ? (
          <div className="field col-12 lg:col-6">
            <InputTypePassword
              state={userInformations.password}
              setState={(newValue) =>
                SetUserState((prevState) => ({
                  ...prevState,
                  password: newValue,
                }))
              }
              label={"Senha"}
              required={IsRegister}
              invalid={IsInvalid.password}
            />
          </div>
        ) : (
          ""
        )}

        <div className="formgrid grid">
          <div className="field col-12 lg:col-12">
            <h1 className="SubsectionAddressTitle">Endereço:</h1>
          </div>

          <div className="field col-12 lg:col-6">
            <InputCep
              state={userInformations}
              setState={SetUserState}
              mask="99999-999"
              label={"Cep"}
              required={true}
              invalid={IsInvalid.cep}
            />
          </div>
          <div className="field col-12 lg:col-6">
            <InputTypeText
              state={userInformations.address.street}
              setState={(newValue: string) =>
                SetUserState((prevState) => ({
                  ...prevState,
                  address: {
                    ...prevState.address,
                    street: newValue,
                  },
                }))
              }
              label={"Rua"}
              required={true}
              invalid={IsInvalid.cep}
            />
          </div>

          <div className="field col-12 lg:col-6">
            <InputTypeText
              state={userInformations.address.neighborhood}
              setState={(newValue: string) =>
                SetUserState((prevState) => ({
                  ...prevState,
                  address: {
                    ...prevState.address,
                    neighborhood: newValue,
                  },
                }))
              }
              label={"Bairro"}
              required={true}
              invalid={IsInvalid.cep}
            />
          </div>
          <div className="field col-12 lg:col-6">
            <InputTypeNumber
              state={userInformations.address.number}
              setState={(newValue: number) =>
                SetUserState((prevState) => ({
                  ...prevState,
                  address: {
                    ...prevState.address,
                    number: newValue,
                  },
                }))
              }
              label={"Número"}
              required={true}
              invalid={IsInvalid.numeroEndereco}
            />
          </div>

          <div className="field col-12 lg:col-6">
            <InputTypeText
              state={userInformations.address.city}
              setState={(newValue: string) =>
                SetUserState((prevState) => ({
                  ...prevState,
                  address: {
                    ...prevState.address,
                    city: newValue,
                  },
                }))
              }
              label={"Cidade"}
              required={true}
              invalid={IsInvalid.cep}
            />
          </div>

          <div className="field col-12">
            <div className="sessaoBotaoSalvar">
              <Button
                label={IsRegister ? "Cadastrar" : "Atualizar"}
                severity="danger"
              />
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
