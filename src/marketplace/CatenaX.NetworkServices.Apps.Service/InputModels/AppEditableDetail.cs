/********************************************************************************
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

namespace CatenaX.NetworkServices.Apps.Service.InputModels;

/// <summary>
/// Model for updating an app.
/// </summary>
/// <param name="Descriptions"></param>
/// <param name="Images"></param>
/// <param name="ProviderUri"></param>
/// <param name="ContactEmail"></param>
/// <param name="ContactNumber"></param>
/// <returns></returns>
public record AppEditableDetail(IEnumerable<Localization> Descriptions, IEnumerable<AppEditableImage> Images, string? ProviderUri, string? ContactEmail, string? ContactNumber);

/// <summary>
/// Model for LanguageCode and Description
/// </summary>
/// <param name="LanguageCode"></param>
/// <param name="LongDescription"></param>
/// <returns></returns>
public record Localization(string LanguageCode, string? LongDescription);

/// <summary>
/// Model for Detail Image
/// </summary>
/// <value></value>
public record AppEditableImage
{
    /// <summary>
    /// Image Id
    /// </summary>
    /// <value></value>
    public string? AppImageId { get; init; }

    /// <summary>
    /// Image Url
    /// </summary>
    /// <value></value>
    public string? ImageUrl { get; init; }
    
    /// <summary>
    /// Default Constructor
    /// </summary>
    public AppEditableImage()
    {
       
    }
    /// <summary>
    /// Parameterized Constructor
    /// </summary>
    /// <param name="imageUrl"></param>
    public AppEditableImage(string? imageUrl)
    {
        ImageUrl = imageUrl;
    }
    /// <summary>
    /// Overloaded Constructor
    /// </summary>
    /// <param name="appImageId"></param>
    /// <param name="imageUrl"></param>
    public AppEditableImage(string? appImageId, string? imageUrl)
    {
        AppImageId = appImageId;
        ImageUrl = imageUrl;
    }
}


