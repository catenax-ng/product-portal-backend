﻿/********************************************************************************
 * Copyright (c) 2021,2022 BMW Group AG
 * Copyright (c) 2021,2022 Contributors to the CatenaX (ng) GitHub Organisation.
 *
 * See the NOTICE file(s) distributed with this work for additional
 * information regarding copyright ownership.
 *
 * This program and the accompanying materials are made available under the
 * terms of the Apache License, Version 2.0 which is available at
 * https://www.apache.org/licenses/LICENSE-2.0.
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations
 * under the License.
 *
 * SPDX-License-Identifier: Apache-2.0
 ********************************************************************************/

// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Org.CatenaX.Ng.Portal.Backend.Provisioning.ProvisioningEntities;

#nullable disable

namespace Provisioning.Migrations.Migrations
{
    [DbContext(typeof(ProvisioningDbContext))]
    [Migration("20221116214721_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("en_US.utf8")
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.HasSequence<int>("client_sequence_sequence_id_seq", "provisioning");

            modelBuilder.HasSequence<int>("identity_provider_sequence_sequence_id_seq", "provisioning");

            modelBuilder.Entity("Org.CatenaX.Ng.Portal.Backend.Provisioning.ProvisioningEntities.ClientSequence", b =>
                {
                    b.Property<int>("SequenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("sequence_id")
                        .HasDefaultValueSql("nextval('provisioning.client_sequence_sequence_id_seq'::regclass)");

                    b.HasKey("SequenceId")
                        .HasName("client_sequence_pkey");

                    b.ToTable("client_sequence", "provisioning");
                });

            modelBuilder.Entity("Org.CatenaX.Ng.Portal.Backend.Provisioning.ProvisioningEntities.IdentityProviderSequence", b =>
                {
                    b.Property<int>("SequenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("sequence_id")
                        .HasDefaultValueSql("nextval('provisioning.identity_provider_sequence_sequence_id_seq'::regclass)");

                    b.HasKey("SequenceId")
                        .HasName("identity_provider_sequence_pkey");

                    b.ToTable("identity_provider_sequence", "provisioning");
                });

            modelBuilder.Entity("Org.CatenaX.Ng.Portal.Backend.Provisioning.ProvisioningEntities.UserPasswordReset", b =>
                {
                    b.Property<string>("UserEntityId")
                        .HasMaxLength(36)
                        .HasColumnType("character varying(36)")
                        .HasColumnName("user_entity_id");

                    b.Property<DateTimeOffset>("PasswordModifiedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("password_modified_at")
                        .HasDefaultValueSql("now()");

                    b.Property<int>("ResetCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("reset_count");

                    b.HasKey("UserEntityId");

                    b.ToTable("user_password_resets", "provisioning");
                });
#pragma warning restore 612, 618
        }
    }
}
