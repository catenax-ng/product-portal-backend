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

using CatenaX.NetworkServices.PortalBackend.DBAccess.Models;
using CatenaX.NetworkServices.PortalBackend.PortalEntities.Enums;

namespace CatenaX.NetworkServices.Notification.Service.BusinessLogic;

/// <summary>
///     Business logic to work with the notifications
/// </summary>
public interface INotificationBusinessLogic
{
    /// <summary>
    ///     Creates a new Notification with the given data
    /// </summary>
    /// <param name="creationData">The data for the creation of the notification.</param>
    /// <param name="companyUserId">Id of the company user the notification is intended for.</param>
    Task<NotificationDetailData> CreateNotificationAsync(NotificationCreationData creationData, Guid companyUserId);

    /// <summary>
    ///     Gets all unread notification for the given user.
    /// </summary>
    /// <param name="iamUserId">The id of the current user</param>
    /// <param name="statusId">OPTIONAL: The status of the notifications</param>
    /// <param name="typeId">OPTIONAL: The type of the notifications</param>
    /// <returns>Returns a collection of the users notification</returns>
    IAsyncEnumerable<NotificationDetailData> GetNotificationsAsync(string iamUserId,
        NotificationStatusId? statusId, NotificationTypeId? typeId);

    /// <summary>
    ///     Gets a specific notification for the given user.
    /// </summary>
    /// <param name="iamUserId">The id of the current user</param>
    /// <param name="notificationId">The id of the notification</param>
    /// <returns>Returns a notification</returns>
    Task<NotificationDetailData> GetNotificationDetailDataAsync(string iamUserId, Guid notificationId);        

    /// <summary>
    /// Gets the notification account for the given user
    /// </summary>
    /// <param name="iamUserId">Id of the current user</param>
    /// <param name="statusId">OPTIONAL: Status of the notifications that should be considered</param>
    /// <returns>Returns the count of the notifications</returns>
    Task<int> GetNotificationCountAsync(string iamUserId, NotificationStatusId? statusId);

    /// <summary>
    /// Sets the status of the notification with the given id to read
    /// </summary>
    /// <param name="iamUserId">Id of the notification receiver</param>
    /// <param name="notificationId">Id of the notification</param>
    /// <param name="notificationStatusId">Id of the notification status</param>
    Task SetNotificationStatusAsync(string iamUserId, Guid notificationId, NotificationStatusId notificationStatusId);

    /// <summary>
    /// Deletes the given notification
    /// </summary>
    /// <param name="iamUserId">Id of the notification receiver</param>
    /// <param name="notificationId">Id of the notification that should be deleted</param>
    Task DeleteNotificationAsync(string iamUserId, Guid notificationId);
}