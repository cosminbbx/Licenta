

using System.Collections.Generic;
using System.Linq;
using DigitalEventPlaner.Services.Services.Event.Dto;
using DigitalEventPlaner.Services.Services.Services.Dto;
using DigitalEventPlaner.Web.Models.MyEvents;
using DigitalEventPlaner.Web.Models.ServicePackage;
using DigitalEventPlaner.Web.Models.Services;
using DigitalEventPlaner.Web.Models.User;
using Omu.ValueInjecter;

namespace DigitalEventPlaner.Web.Helpers
{
    public static class GeneralHelper
    {
        public static EventWrappersSortedViewModel MapEventWrapperList(List<EventWrapper> eventWrappers)
        {
            var viewModelList = new List<EventWrapperViewModel>();

            foreach (var ew in eventWrappers)
            {
                var eventWrapper = new EventWrapperViewModel().InjectFrom(ew) as EventWrapperViewModel;
                eventWrapper.ServiceWrappers = MapServiceWrapperList(ew.ServiceWrappers);
                viewModelList.Add(eventWrapper);
            }

            return new EventWrappersSortedViewModel()
            {
                NeedsApproval = viewModelList.Where(x => x.EventStatus == DataLayer.Enumerations.EventStatus.Planning).OrderBy(y => y.EventDate).ToList(),
                ToBeDone = viewModelList.Where(x => x.EventStatus == DataLayer.Enumerations.EventStatus.ToBeDone).OrderBy(y => y.EventDate).ToList(),
                Done = viewModelList.Where(x => x.EventStatus == DataLayer.Enumerations.EventStatus.Done).OrderBy(y => y.EventDate).ToList(),
                Canceled = viewModelList.Where(x => x.EventStatus == DataLayer.Enumerations.EventStatus.Cancelled).OrderBy(y => y.EventDate).ToList()
            };
        }
        public static List<ServiceWrapperViewModel> MapServiceWrapperList(List<ServiceWrapper> serviceWrappers)
        {
            var serviceViewModelList = new List<ServiceWrapperViewModel>();
            foreach (var serviceWrapper in serviceWrappers)
            {
                var servicePackagesViewModels = new List<ServicePackageViewModel>();
                serviceWrapper.ServicePackages.ForEach(x => servicePackagesViewModels.Add(new ServicePackageViewModel().InjectFrom(x) as ServicePackageViewModel));
                serviceViewModelList.Add(new ServiceWrapperViewModel()
                {
                    Service = new ServiceViewModel().InjectFrom(serviceWrapper.Service) as ServiceViewModel,
                    Status = serviceWrapper.Status,
                    User = new UserViewModel().InjectFrom(serviceWrapper.User) as UserViewModel,
                    ProfilePictureUri = serviceWrapper.ProfilePictureUri,
                    EventServiceId = serviceWrapper.EventServiceId,
                    ServicePackages = servicePackagesViewModels
                }) ;
            }
            return serviceViewModelList;
        }

        public static ServiceWrapperViewModel MapServiceWrapper(ServiceWrapper serviceWrapper)
        {
            var servicePackagesViewModels = new List<ServicePackageViewModel>();
            serviceWrapper.ServicePackages.ForEach(x => servicePackagesViewModels.Add(new ServicePackageViewModel().InjectFrom(x) as ServicePackageViewModel));
            return new ServiceWrapperViewModel()
            {
                Service = new ServiceViewModel().InjectFrom(serviceWrapper.Service) as ServiceViewModel,
                Status = serviceWrapper.Status,
                ServicePackages = servicePackagesViewModels
            };
        }

        public static EventRequestSortedViewModel MapServiceRequestSortedList(List<EventRequestDto> eventRequests)
        {
            var serviceViewModelList = new List<EventRequestViewModel>();
            foreach(var er in eventRequests)
            {
                var viewModel = new EventRequestViewModel().InjectFrom(er) as EventRequestViewModel;
                viewModel.User = new UserViewModel().InjectFrom(er.User) as UserViewModel;
                viewModel.EventService = new EventServiceViewModel().InjectFrom(er.EventService) as EventServiceViewModel;
                viewModel.ServiceWrapper = MapServiceWrapper(er.ServiceWrapper);
                serviceViewModelList.Add(viewModel);
            }

            return new EventRequestSortedViewModel()
            {
                NeedsApproval = serviceViewModelList.Where(x => x.EventService.Status == DataLayer.Enumerations.RequestStatus.Requested).OrderBy(y => y.EventDate).ToList(),
                Accepted = serviceViewModelList.Where(x => x.EventService.Status == DataLayer.Enumerations.RequestStatus.Accepted).OrderBy(y => y.EventDate).ToList(),
                Canceled = serviceViewModelList.Where(x => x.EventService.Status == DataLayer.Enumerations.RequestStatus.Cancelled).OrderBy(y => y.EventDate).ToList()
            };
        }

        public static List<EventRequestViewModel> MapServiceRequestList(List<EventRequestDto> eventRequests)
        {
            var serviceViewModelList = new List<EventRequestViewModel>();
            foreach (var er in eventRequests)
            {
                var viewModel = new EventRequestViewModel().InjectFrom(er) as EventRequestViewModel;
                viewModel.User = new UserViewModel().InjectFrom(er.User) as UserViewModel;
                viewModel.EventService = new EventServiceViewModel().InjectFrom(er.EventService) as EventServiceViewModel;
                viewModel.ServiceWrapper = MapServiceWrapper(er.ServiceWrapper);
                serviceViewModelList.Add(viewModel);
            }

            return serviceViewModelList;
        }
    }
}
