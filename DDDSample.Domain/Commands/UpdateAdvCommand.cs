﻿using System;
using DDDSample.Domain.Validations;

namespace DDDSample.Domain.Commands
{
    public class UpdateAdvCommand : AdvCommand
    {
        public UpdateAdvCommand(int id, string marca, string modelo, string versao, int ano, int quilometragem, string observacao)
        {
            ID = id;
            Marca = marca;
            Modelo = modelo;
            Versao = versao;
            Ano = ano;
            Quilometragem = quilometragem;
            Observacao = observacao;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateAdvCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
