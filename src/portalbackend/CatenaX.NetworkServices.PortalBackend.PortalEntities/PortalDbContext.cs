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

using CatenaX.NetworkServices.PortalBackend.PortalEntities.AuditEntities;
using CatenaX.NetworkServices.PortalBackend.PortalEntities.Entities;
using CatenaX.NetworkServices.PortalBackend.PortalEntities.Enums;
using Microsoft.EntityFrameworkCore;

namespace CatenaX.NetworkServices.PortalBackend.PortalEntities;

public class PortalDbContext : DbContext
{
    protected PortalDbContext()
    {
    }

    public PortalDbContext(DbContextOptions<PortalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; } = default!;
    public virtual DbSet<Agreement> Agreements { get; set; } = default!;
    public virtual DbSet<AgreementAssignedCompanyRole> AgreementAssignedCompanyRoles { get; set; } = default!;
    public virtual DbSet<AgreementAssignedDocumentTemplate> AgreementAssignedDocumentTemplates { get; set; } = default!;
    public virtual DbSet<AgreementCategory> AgreementCategories { get; set; } = default!;
    public virtual DbSet<App> Apps { get; set; } = default!;
    public virtual DbSet<AppInstance> AppInstances { get; set; } = default!;
    public virtual DbSet<AppAssignedLicense> AppAssignedLicenses { get; set; } = default!;
    public virtual DbSet<AppAssignedUseCase> AppAssignedUseCases { get; set; } = default!;
    public virtual DbSet<AppDescription> AppDescriptions { get; set; } = default!;
    public virtual DbSet<AppDetailImage> AppDetailImages { get; set; } = default!;
    public virtual DbSet<AppLanguage> AppLanguages { get; set; } = default!;
    public virtual DbSet<AppLicense> AppLicenses { get; set; } = default!;
    public virtual DbSet<AppStatus> AppStatuses { get; set; } = default!;
    public virtual DbSet<AppTag> AppTags { get; set; } = default!;
    public virtual DbSet<Company> Companies { get; set; } = default!;
    public virtual DbSet<CompanyApplication> CompanyApplications { get; set; } = default!;
    public virtual DbSet<CompanyApplicationStatus> CompanyApplicationStatuses { get; set; } = default!;
    public virtual DbSet<CompanyAssignedApp> CompanyAssignedApps { get; set; } = default!;
    public virtual DbSet<AppSubscriptionStatus> AppSubscriptionStatuses { get; set; } = default!;
    public virtual DbSet<CompanyAssignedRole> CompanyAssignedRoles { get; set; } = default!;
    public virtual DbSet<CompanyAssignedUseCase> CompanyAssignedUseCases { get; set; } = default!;
    public virtual DbSet<CompanyIdentityProvider> CompanyIdentityProviders { get; set; } = default!;
    public virtual DbSet<CompanyRole> CompanyRoles { get; set; } = default!;
    public virtual DbSet<CompanyRoleDescription> CompanyRoleDescriptions { get; set; } = default!;
    public virtual DbSet<CompanyServiceAccount> CompanyServiceAccounts { get; set; } = default!;
    public virtual DbSet<CompanyServiceAccountAssignedRole> CompanyServiceAccountAssignedRoles { get; set; } = default!;
    public virtual DbSet<CompanyServiceAccountStatus> CompanyServiceAccountStatuses { get; set; } = default!;
    public virtual DbSet<CompanyStatus> CompanyStatuses { get; set; } = default!;
    public virtual DbSet<CompanyUser> CompanyUsers { get; set; } = default!;
    public virtual DbSet<CompanyUserAssignedAppFavourite> CompanyUserAssignedAppFavourites { get; set; } = default!;
    public virtual DbSet<CompanyUserAssignedBusinessPartner> CompanyUserAssignedBusinessPartners { get; set; } = default!;
    public virtual DbSet<CompanyUserAssignedRole> CompanyUserAssignedRoles { get; set; } = default!;
    public virtual DbSet<Connector> Connectors { get; set; } = default!;
    public virtual DbSet<ConnectorStatus> ConnectorStatuses { get; set; } = default!;
    public virtual DbSet<ConnectorType> ConnectorTypes { get; set; } = default!;
    public virtual DbSet<UserRole> UserRoles { get; set; } = default!;
    public virtual DbSet<UserRoleDescription> UserRoleDescriptions { get; set; } = default!;
    public virtual DbSet<CompanyUserStatus> CompanyUserStatuses { get; set; } = default!;
    public virtual DbSet<Consent> Consents { get; set; } = default!;
    public virtual DbSet<ConsentStatus> ConsentStatuses { get; set; } = default!;
    public virtual DbSet<Country> Countries { get; set; } = default!;
    public virtual DbSet<Document> Documents { get; set; } = default!;
    public virtual DbSet<DocumentTemplate> DocumentTemplates { get; set; } = default!;
    public virtual DbSet<DocumentType> DocumentTypes { get; set; } = default!;
    public virtual DbSet<DocumentStatus> DocumentStatus { get; set; } = default!;
    public virtual DbSet<IamClient> IamClients { get; set; } = default!;
    public virtual DbSet<IamIdentityProvider> IamIdentityProviders { get; set; } = default!;
    public virtual DbSet<IamServiceAccount> IamServiceAccounts { get; set; } = default!;
    public virtual DbSet<IamUser> IamUsers { get; set; } = default!;
    public virtual DbSet<IdentityProvider> IdentityProviders { get; set; } = default!;
    public virtual DbSet<IdentityProviderCategory> IdentityProviderCategories { get; set; } = default!;
    public virtual DbSet<Invitation> Invitations { get; set; } = default!;
    public virtual DbSet<InvitationStatus> InvitationStatuses { get; set; } = default!;
    public virtual DbSet<Language> Languages { get; set; } = default!;
    public virtual DbSet<Notification> Notifications { get; set; } = default!;
    public virtual DbSet<UseCase> UseCases { get; set; } = default!;
    public virtual DbSet<Service> Services { get; set; } = default!;
    public virtual DbSet<ServiceStatus> ServiceStatuses { get; set; } = default!;
    public virtual DbSet<ServiceLicense> ServiceLicenses { get; set; } = default!;
    public virtual DbSet<ServiceDescription> ServiceDescriptions { get; set; } = default!;
    public virtual DbSet<ServiceSubscriptionStatus> ServiceSubscriptionStatuses { get; set; } = default!;
    public virtual DbSet<CompanyAssignedService> CompanyAssignedServices { get; set; } = default!;
    public virtual DbSet<ServiceAssignedLicense> ServiceAssignedLicenses { get; set; } = default!;
    public virtual DbSet<AuditCompanyApplication> AuditCompanyApplications { get; set; } = default!;
    public virtual DbSet<AuditCompanyAssignedApp> AuditCompanyAssignedApps { get; set; } = default!;
    public virtual DbSet<AuditCompanyUser> AuditCompanyUsers { get; set; } = default!;
    public virtual DbSet<AuditCompanyUserAssignedRole> AuditCompanyUserAssignedRoles { get; set; } = default!;
    public virtual DbSet<AuditService> AuditServices { get; set; } = default!;
    public virtual DbSet<AppAssignedDocument> AppAssignedDocuments { get; set; } = default!;
    public virtual DbSet<AuditApp> AuditApps { get; set; } = default!;
    public virtual DbSet<AuditUserRole> AuditUserRoles { get; set; } = default!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");
        modelBuilder.HasDefaultSchema("portal");

        modelBuilder.Entity<Agreement>(entity =>
        {
            entity.HasOne(d => d.AgreementCategory)
                .WithMany(p => p!.Agreements)
                .HasForeignKey(d => d.AgreementCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IssuerCompany)
                .WithMany(p => p!.Agreements)
                .HasForeignKey(d => d.IssuerCompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<AgreementAssignedCompanyRole>(entity =>
        {
            entity.HasKey(e => new { e.AgreementId, e.CompanyRoleId });

            entity.HasOne(d => d.Agreement)
                .WithMany(p => p!.AgreementAssignedCompanyRoles)
                .HasForeignKey(d => d.AgreementId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.CompanyRole)
                .WithMany(p => p!.AgreementAssignedCompanyRoles!)
                .HasForeignKey(d => d.CompanyRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<AgreementAssignedDocumentTemplate>(entity =>
        {
            entity.HasKey(e => new { e.AgreementId, e.DocumentTemplateId });

            entity.HasOne(d => d.Agreement)
                .WithMany(p => p!.AgreementAssignedDocumentTemplates)
                .HasForeignKey(d => d.AgreementId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.DocumentTemplate)
                .WithOne(p => p!.AgreementAssignedDocumentTemplate!)
                .HasForeignKey<AgreementAssignedDocumentTemplate>(d => d.DocumentTemplateId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<AgreementCategory>()
            .HasData(
                Enum.GetValues(typeof(AgreementCategoryId))
                    .Cast<AgreementCategoryId>()
                    .Select(e => new AgreementCategory(e))
            );

        modelBuilder.Entity<App>(entity =>
        {
            entity.HasOne(d => d.ProviderCompany)
                .WithMany(p => p!.ProvidedApps);

            entity.HasOne(x => x.SalesManager)
                .WithMany(x => x!.SalesManagerOfApps)
                .HasForeignKey(x => x.SalesManagerId);

            entity.HasMany(p => p.Companies)
                .WithMany(p => p.BoughtApps)
                .UsingEntity<CompanyAssignedApp>(
                    j => j
                        .HasOne(d => d.Company!)
                        .WithMany()
                        .HasForeignKey(d => d.CompanyId)
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j => j
                        .HasOne(d => d.App!)
                        .WithMany()
                        .HasForeignKey(d => d.AppId)
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey(e => new { e.CompanyId, e.AppId });
                        j.HasOne(e => e.AppSubscriptionStatus)
                            .WithMany(e => e.AppSubscriptions)
                            .HasForeignKey(e => e.AppSubscriptionStatusId)
                            .OnDelete(DeleteBehavior.ClientSetNull);
                        j.HasOne(e => e.AppInstance)
                            .WithMany(e => e.CompanyAssignedApps)
                            .HasForeignKey(e => e.AppInstanceId)
                            .OnDelete(DeleteBehavior.ClientSetNull);
                        j.Property(e => e.AppSubscriptionStatusId)
                            .HasDefaultValue(AppSubscriptionStatusId.PENDING);
                    }
                );

            entity.HasMany(a => a.SupportedLanguages)
                .WithMany(l => l.SupportingApps)
                .UsingEntity<AppLanguage>(
                    j => j
                        .HasOne(d => d.Language!)
                        .WithMany()
                        .HasForeignKey(d => d.LanguageShortName)
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j => j
                        .HasOne(d => d.App!)
                        .WithMany()
                        .HasForeignKey(d => d.AppId)
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey(e => new { e.AppId, e.LanguageShortName });
                    }
                );
            
            entity.HasMany(p => p.AppLicenses)
                .WithMany(p => p.Apps)
                .UsingEntity<AppAssignedLicense>(
                    j => j
                        .HasOne(d => d.AppLicense!)
                        .WithMany()
                        .HasForeignKey(d => d.AppLicenseId)
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j => j
                        .HasOne(d => d.App!)
                        .WithMany()
                        .HasForeignKey(d => d.AppId)
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey(e => new { e.AppId, e.AppLicenseId });
                    });
            
            entity.HasMany(p => p.UseCases)
                .WithMany(p => p.Apps)
                .UsingEntity<AppAssignedUseCase>(
                    j => j
                        .HasOne(d => d.UseCase!)
                        .WithMany()
                        .HasForeignKey(d => d.UseCaseId)
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j => j
                        .HasOne(d => d.App!)
                        .WithMany()
                        .HasForeignKey(d => d.AppId)
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey(e => new { e.AppId, e.UseCaseId });
                    });
            
            entity.HasMany(p => p.Documents)
                .WithMany(p => p.Apps)
                .UsingEntity<AppAssignedDocument>(
                    j => j
                        .HasOne(d => d.Document!)
                        .WithMany()
                        .HasForeignKey(d => d.DocumentId)
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j => j
                        .HasOne(d => d.App!)
                        .WithMany()
                        .HasForeignKey(d => d.AppId)
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey(e => new { e.AppId, e.DocumentId });
                    });

            entity.HasMany(p => p.CompanyAssignedApps)
                .WithOne(d => d.App)
                .HasForeignKey(d => d.AppId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            entity.ToTable("apps");
        });

        modelBuilder.Entity<AppInstance>(entity =>
        {
            entity.HasOne(x => x.App)
                .WithMany(x => x.AppInstances)
                .HasForeignKey(x => x.AppId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(x => x.IamClient)
                .WithMany(x => x.AppInstances)
                .HasForeignKey(x => x.IamClientId)
                .OnDelete(DeleteBehavior.SetNull);
        });
        
        modelBuilder.Entity<AppDescription>(entity =>
        {
            entity.HasKey(e => new { e.AppId, e.LanguageShortName });

            entity.HasOne(d => d.App)
                .WithMany(p => p!.AppDescriptions)
                .HasForeignKey(d => d.AppId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Language)
                .WithMany(p => p!.AppDescriptions)
                .HasForeignKey(d => d.LanguageShortName)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<AppDetailImage>()
            .HasOne(d => d.App)
                .WithMany(p => p!.AppDetailImages)
                .HasForeignKey(d => d.AppId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        modelBuilder.Entity<AppStatus>()
            .HasData(
                Enum.GetValues(typeof(AppStatusId))
                    .Cast<AppStatusId>()
                    .Select(e => new AppStatus(e))
            );

        modelBuilder.Entity<AppTag>(entity =>
        {
            entity.HasKey(e => new { e.AppId, e.Name });

            entity.HasOne(d => d.App)
                .WithMany(p => p!.Tags)
                .HasForeignKey(d => d.AppId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<AuditOperation>()
            .HasData(
                Enum.GetValues(typeof(AuditOperationId))
                    .Cast<AuditOperationId>()
                    .Select(e => new AuditOperation(e))
            );

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasMany(p => p.CompanyRoles)
                .WithMany(p => p.Companies)
                .UsingEntity<CompanyAssignedRole>(
                    j => j
                        .HasOne(d => d.CompanyRole!)
                        .WithMany()
                        .HasForeignKey(d => d.CompanyRoleId)
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j => j
                        .HasOne(d => d.Company!)
                        .WithMany()
                        .HasForeignKey(d => d.CompanyId)
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey(e => new { e.CompanyId, e.CompanyRoleId });
                    }
                );

            entity.HasMany(p => p.CompanyAssignedRoles)
                .WithOne(d => d.Company!)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasMany(p => p.CompanyAssignedApps)
                .WithOne(d => d.Company)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasMany(p => p.UseCases)
                .WithMany(p => p.Companies)
                .UsingEntity<CompanyAssignedUseCase>(
                    j => j
                        .HasOne(d => d.UseCase!)
                        .WithMany()
                        .HasForeignKey(d => d.UseCaseId)
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j => j
                        .HasOne(d => d.Company!)
                        .WithMany()
                        .HasForeignKey(d => d.CompanyId)
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey(e => new { e.CompanyId, e.UseCaseId });
                    }
                );

            entity.HasMany(p => p.IdentityProviders)
                .WithMany(p => p.Companies)
                .UsingEntity<CompanyIdentityProvider>(
                    j => j
                        .HasOne(pt => pt.IdentityProvider!)
                        .WithMany()
                        .HasForeignKey(pt => pt.IdentityProviderId)
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j => j
                        .HasOne(pt => pt.Company!)
                        .WithMany()
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasForeignKey(pt => pt.CompanyId),
                    j => 
                    {
                        j.HasKey(e => new { e.CompanyId, e.IdentityProviderId });
                    }
                );
        });

        modelBuilder.Entity<CompanyApplication>()
            .HasOne(d => d.Company)
                .WithMany(p => p!.CompanyApplications)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        
        modelBuilder.Entity<AuditCompanyApplication>(x =>
        {
            x.HasBaseType((Type?)null);

            x.Ignore(x => x.ApplicationStatus);
            x.Ignore(x => x.Company);
            x.Ignore(x => x.Invitations);
            x.ToTable("audit_company_applications_cplp_1255_audit_company_applications");
        });

        modelBuilder.Entity<CompanyApplicationStatus>()
            .HasData(
                Enum.GetValues(typeof(CompanyApplicationStatusId))
                    .Cast<CompanyApplicationStatusId>()
                    .Select(e => new CompanyApplicationStatus(e))
            );

        modelBuilder.Entity<CompanyIdentityProvider>()
            .HasOne(d => d.IdentityProvider)
            .WithMany(p => p.CompanyIdentityProviders)
            .HasForeignKey(d => d.IdentityProviderId);

        modelBuilder.Entity<AuditCompanyAssignedApp>(x =>
        {
            x.HasBaseType((Type?)null);

            x.Ignore(x => x.App);
            x.Ignore(x => x.Company);
            x.Ignore(x => x.AppSubscriptionStatus);
            x.Ignore(x => x.AppInstance);

            x.ToTable("audit_company_assigned_apps_cplp_1254_db_audit");
        });

        modelBuilder.Entity<CompanyRole>()
            .HasData(
                Enum.GetValues(typeof(CompanyRoleId))
                    .Cast<CompanyRoleId>()
                    .Select(e => new CompanyRole(e))
            );

        modelBuilder.Entity<CompanyRoleDescription>(entity =>
        {
            entity.HasKey(e => new { e.CompanyRoleId, e.LanguageShortName });

            entity.HasData(StaticPortalData.CompanyRoleDescriptions);
        });

        modelBuilder.Entity<CompanyServiceAccount>(entity =>
        {
            entity.HasOne(d => d.Company)
                .WithMany(p => p!.CompanyServiceAccounts)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.CompanyServiceAccountStatus)
                .WithMany(p => p!.CompanyServiceAccounts)
                .HasForeignKey(d => d.CompanyServiceAccountStatusId);
                
            entity.HasMany(p => p.UserRoles)
                .WithMany(p => p.CompanyServiceAccounts)
                .UsingEntity<CompanyServiceAccountAssignedRole>(
                    j => j
                        .HasOne(d => d.UserRole!)
                        .WithMany()
                        .HasForeignKey(d => d.UserRoleId)
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j => j
                        .HasOne(d => d.CompanyServiceAccount!)
                        .WithMany()
                        .HasForeignKey(d => d.CompanyServiceAccountId)
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey(e => new { e.CompanyServiceAccountId, e.UserRoleId });
                    });

            entity.HasMany(p => p.CompanyServiceAccountAssignedRoles)
                .WithOne(d => d.CompanyServiceAccount!);
        });
        
        modelBuilder.Entity<AuditUserRole>(x =>
        {
            x.HasBaseType((Type?)null);

            x.Ignore(x => x.App);
            x.Ignore(x => x.CompanyUsers);
            x.Ignore(x => x.CompanyServiceAccounts);
            x.Ignore(x => x.UserRoleDescriptions);         
            x.ToTable("audit_app_user_roles_cplp_1313_db_audit_apps");
        });

        modelBuilder.Entity<CompanyServiceAccountStatus>()
            .HasData(
                Enum.GetValues(typeof(CompanyServiceAccountStatusId))
                    .Cast<CompanyServiceAccountStatusId>()
                    .Select(e => new CompanyServiceAccountStatus(e))
            );

        modelBuilder.Entity<CompanyStatus>()
            .HasData(
                Enum.GetValues(typeof(CompanyStatusId))
                    .Cast<CompanyStatusId>()
                    .Select(e => new CompanyStatus(e))
            );

        modelBuilder.Entity<CompanyUser>(entity =>
        {
            entity.HasOne(d => d.Company)
                .WithMany(p => p!.CompanyUsers)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull);
                
            entity.HasMany(p => p.Apps)
                .WithMany(p => p.CompanyUsers)
                .UsingEntity<CompanyUserAssignedAppFavourite>(
                    j => j
                        .HasOne(d => d.App!)
                        .WithMany()
                        .HasForeignKey(d => d.AppId)
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j => j
                        .HasOne(d => d.CompanyUser!)
                        .WithMany()
                        .HasForeignKey(d => d.CompanyUserId)
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey(e => new { e.CompanyUserId, e.AppId });
                    });

            entity.HasMany(p => p.UserRoles)
                .WithMany(p => p.CompanyUsers)
                .UsingEntity<CompanyUserAssignedRole>(
                    j => j
                        .HasOne(d => d.UserRole!)
                        .WithMany()
                        .HasForeignKey(d => d.UserRoleId)
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j => j
                        .HasOne(d => d.CompanyUser!)
                        .WithMany()
                        .HasForeignKey(d => d.CompanyUserId)
                        .OnDelete(DeleteBehavior.ClientSetNull),
                        j =>
                        {
                            j.HasKey(e => new { e.CompanyUserId, e.UserRoleId });
                        });

            entity.HasMany(p => p.CompanyUserAssignedRoles)
                .WithOne(d => d.CompanyUser!);

            entity.HasMany(p => p.CompanyUserAssignedBusinessPartners)
                .WithOne(d => d.CompanyUser);

            entity.ToTable("company_users");
        });
        
        modelBuilder.Entity<AuditCompanyUser>(entity =>
        {
            entity.HasBaseType((Type?)null);

            entity.Ignore(x => x.Company);
            entity.Ignore(x => x.IamUser);
            entity.Ignore(x => x.Consents);
            entity.Ignore(x => x.Documents);
            entity.Ignore(x => x.Invitations);
            entity.Ignore(x => x.Apps);
            entity.Ignore(x => x.SalesManagerOfApps);
            entity.Ignore(x => x.UserRoles);
            entity.Ignore(x => x.CompanyUserAssignedRoles);
            entity.Ignore(x => x.CompanyUserAssignedBusinessPartners);
            entity.Ignore(x => x.Notifications);
            entity.Ignore(x => x.CreatedNotifications);
            entity.Ignore(x => x.SalesManagerOfServices);
            entity.Ignore(x => x.RequesterOfCompanyAssignedServices);

            entity.ToTable("audit_company_users_cplp_1254_db_audit");
        });

        modelBuilder.Entity<AuditCompanyUserAssignedRole>(x =>
        {
            x.HasBaseType((Type?)null);

            x.Ignore(x => x.CompanyUser);
            x.Ignore(x => x.UserRole);

            x.ToTable("audit_company_user_assigned_roles_cplp_1255_audit_company_applications");
        });

        modelBuilder.Entity<AuditApp>(x =>
        {
            x.HasBaseType((Type?)null);

            x.Ignore(x => x.AppStatus);
            x.Ignore(x => x.Agreements);
            x.Ignore(x => x.AppDescriptions);
            x.Ignore(x => x.AppDetailImages);
            x.Ignore(x => x.AppInstances);
            x.Ignore(x => x.AppLicenses);
            x.Ignore(x => x.Companies);
            x.Ignore(x => x.CompanyAssignedApps);
            x.Ignore(x => x.CompanyUsers);
            x.Ignore(x => x.Documents);
            x.Ignore(x => x.ProviderCompany);
            x.Ignore(x => x.SalesManager);
            x.Ignore(x => x.SupportedLanguages);
            x.Ignore(x => x.Tags);
            x.Ignore(x => x.UseCases);
            x.Ignore(x => x.UserRoles);
            
            x.ToTable("audit_apps_cplp_1313_db_audit_apps");
        });

        modelBuilder.Entity<CompanyUserAssignedBusinessPartner>()
            .HasKey(e => new { e.CompanyUserId, e.BusinessPartnerNumber });

        modelBuilder.Entity<UserRoleDescription>().HasKey(e => new { e.UserRoleId, e.LanguageShortName });

        modelBuilder.Entity<CompanyUserStatus>()
            .HasData(
                Enum.GetValues(typeof(CompanyUserStatusId))
                    .Cast<CompanyUserStatusId>()
                    .Select(e => new CompanyUserStatus(e))
            );

        modelBuilder.Entity<Consent>(entity =>
        {
            entity.HasOne(d => d.Agreement)
                .WithMany(p => p!.Consents)
                .HasForeignKey(d => d.AgreementId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Company)
                .WithMany(p => p!.Consents)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.CompanyUser)
                .WithMany(p => p!.Consents)
                .HasForeignKey(d => d.CompanyUserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ConsentStatus)
                .WithMany(p => p!.Consents)
                .HasForeignKey(d => d.ConsentStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ConsentStatus>()
            .HasData(
                Enum.GetValues(typeof(ConsentStatusId))
                    .Cast<ConsentStatusId>()
                    .Select(e => new ConsentStatus(e))
            );

        modelBuilder.Entity<Country>(entity =>
        {
            entity.Property(e => e.Alpha2Code)
                .IsFixedLength();

            entity.Property(e => e.Alpha3Code)
                .IsFixedLength();

            entity.HasData(StaticPortalData.Countries);
        });

        modelBuilder.Entity<DocumentType>()
            .HasData(
                Enum.GetValues(typeof(DocumentTypeId))
                    .Cast<DocumentTypeId>()
                    .Select(e => new DocumentType(e))
            );

        modelBuilder.Entity<DocumentStatus>()
            .HasData(
                Enum.GetValues(typeof(DocumentStatusId))
                    .Cast<DocumentStatusId>()
                    .Select(e => new DocumentStatus(e))
            );

        modelBuilder.Entity<IamClient>().HasIndex(e => e.ClientClientId).IsUnique();

        modelBuilder.Entity<IamIdentityProvider>()
            .HasOne(d => d.IdentityProvider)
                .WithOne(p => p!.IamIdentityProvider!)
                .HasForeignKey<IamIdentityProvider>(d => d.IdentityProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        modelBuilder.Entity<IamServiceAccount>(entity =>
        {
            entity.HasIndex(e => e.ClientClientId)
                .IsUnique();

            entity.HasIndex(e => e.UserEntityId)
                .IsUnique();

            entity.HasOne(d => d.CompanyServiceAccount)
                .WithOne(p => p!.IamServiceAccount!)
                .HasForeignKey<IamServiceAccount>(d => d.CompanyServiceAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<IamUser>()
            .HasOne(d => d.CompanyUser)
                .WithOne(p => p!.IamUser!)
                .HasForeignKey<IamUser>(d => d.CompanyUserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        modelBuilder.Entity<IdentityProvider>()
            .HasOne(d => d.IdentityProviderCategory)
                .WithMany(p => p!.IdentityProviders)
                .HasForeignKey(d => d.IdentityProviderCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        modelBuilder.Entity<IdentityProviderCategory>()
            .HasData(
                Enum.GetValues(typeof(IdentityProviderCategoryId))
                    .Cast<IdentityProviderCategoryId>()
                    .Select(e => new IdentityProviderCategory(e))
            );

        modelBuilder.Entity<Invitation>(entity =>
        {
            entity.HasOne(d => d.CompanyUser)
                .WithMany(p => p!.Invitations)
                .HasForeignKey(d => d.CompanyUserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.InvitationStatus)
                .WithMany(p => p!.Invitations)
                .HasForeignKey(d => d.InvitationStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<InvitationStatus>()
            .HasData(
                Enum.GetValues(typeof(InvitationStatusId))
                    .Cast<InvitationStatusId>()
                    .Select(e => new InvitationStatus(e))
            );

        modelBuilder.Entity<Connector>(entity =>
        {
            entity.HasOne(d => d.Status)
                .WithMany(p => p.Connectors)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Type)
                .WithMany(p => p.Connectors)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Provider)
                .WithMany(p => p.ProvidedConnectors);

            entity.HasOne(d => d.Host)
                .WithMany(p => p.HostedConnectors);
        });

        modelBuilder.Entity<ConnectorStatus>()
            .HasData(
                Enum.GetValues(typeof(ConnectorStatusId))
                    .Cast<ConnectorStatusId>()
                    .Select(e => new ConnectorStatus(e))
            );

        modelBuilder.Entity<ConnectorType>()
            .HasData(
                Enum.GetValues(typeof(ConnectorTypeId))
                    .Cast<ConnectorTypeId>()
                    .Select(e => new ConnectorType(e))
            );

        modelBuilder.Entity<Language>(entity =>
        {
            entity.Property(e => e.ShortName)
                .IsFixedLength();

            entity.HasData(StaticPortalData.Languages);
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.Property(x => x.DueDate)
                .IsRequired(false);

            entity.HasOne(d => d.Receiver)
                .WithMany(p => p!.Notifications)
                .HasForeignKey(d => d.ReceiverUserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Creator)
                .WithMany(p => p!.CreatedNotifications)
                .HasForeignKey(d => d.CreatorUserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.NotificationType)
                .WithMany(p => p!.Notifications)
                .HasForeignKey(d => d.NotificationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<NotificationType>()
            .HasData(
                Enum.GetValues(typeof(NotificationTypeId))
                    .Cast<NotificationTypeId>()
                    .Select(e => new NotificationType(e))
            );

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasOne(e => e.ProviderCompany)
                .WithMany(e => e.ProvidedServices)
                .HasForeignKey(e => e.ProviderCompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(x => x.SalesManager)
                .WithMany(x => x.SalesManagerOfServices)
                .HasForeignKey(x => x.SalesManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(e => e.ServiceStatus)
                .WithMany(e => e.Services)
                .HasForeignKey(e => e.ServiceStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            
            entity.HasMany(p => p.Companies)
                .WithMany(p => p.CompanyAssignedServices)
                .UsingEntity<CompanyAssignedService>(
                    j => j
                        .HasOne(d => d.Company!)
                        .WithMany()
                        .HasForeignKey(d => d.CompanyId)
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j => j
                        .HasOne(d => d.Service!)
                        .WithMany()
                        .HasForeignKey(d => d.ServiceId)
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey(e => new { e.ServiceId, e.CompanyId });
                        j.HasOne(e => e.ServiceSubscriptionStatus)
                            .WithMany(e => e.CompanyAssignedServices)
                            .HasForeignKey(e => e.ServiceSubscriptionStatusId)
                            .OnDelete(DeleteBehavior.ClientSetNull);
                        j.HasOne(e => e.Requester)
                            .WithMany(e => e.RequesterOfCompanyAssignedServices)
                            .HasForeignKey(e => e.RequesterId)
                            .OnDelete(DeleteBehavior.ClientSetNull);
                        j.Property(e => e.ServiceSubscriptionStatusId)
                            .HasDefaultValue(ServiceSubscriptionStatusId.PENDING);
                    }
                );

            entity.HasMany(x => x.ServiceDescriptions)
                .WithOne(x => x.Service)
                .HasForeignKey(x => x.ServiceId);

            entity.HasMany(p => p.ServiceLicenses)
                .WithMany(p => p.Services)
                .UsingEntity<ServiceAssignedLicense>(
                    j => j
                        .HasOne(d => d.ServiceLicense!)
                        .WithMany()
                        .HasForeignKey(d => d.ServiceLicenseId)
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j => j
                        .HasOne(d => d.Service!)
                        .WithMany()
                        .HasForeignKey(d => d.ServiceId)
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey(e => new { e.ServiceId, e.ServiceLicenseId });
                    }
                );

            entity.ToTable("services");
        });

        modelBuilder.Entity<AuditService>(x =>
        {
            x.HasBaseType((Type?)null);

            x.Ignore(x => x.ProviderCompany);
            x.Ignore(x => x.SalesManager);
            x.Ignore(x => x.ServiceStatus);
            x.Ignore(x => x.Companies);
            x.Ignore(x => x.ServiceDescriptions);
            x.Ignore(x => x.ServiceLicenses);

            x.ToTable("audit_services_cplp_1213_add_services");
        });

        modelBuilder.Entity<ServiceStatus>()
            .HasData(
                Enum.GetValues(typeof(ServiceStatusId))
                    .Cast<ServiceStatusId>()
                    .Select(e => new ServiceStatus(e))
            );
        
        modelBuilder.Entity<ServiceSubscriptionStatus>()
            .HasData(
                Enum.GetValues(typeof(ServiceSubscriptionStatusId))
                    .Cast<ServiceSubscriptionStatusId>()
                    .Select(e => new ServiceSubscriptionStatus(e))
            );
        
        modelBuilder.Entity<UseCase>().HasData(StaticPortalData.UseCases);

        modelBuilder.Entity<AppSubscriptionStatus>()
            .HasData(
                Enum.GetValues(typeof(AppSubscriptionStatusId))
                    .Cast<AppSubscriptionStatusId>()
                    .Select(e => new AppSubscriptionStatus(e))
            );
    }
}
