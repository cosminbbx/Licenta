

using System.Collections.Generic;
using DigitalEventPlaner.Services.Services.Event.Dto;
using DigitalEventPlaner.Services.Services.Services.Dto;
using DigitalEventPlaner.Web.Models.MyEvents;
using DigitalEventPlaner.Web.Models.ServicePackage;
using DigitalEventPlaner.Web.Models.Services;
using Omu.ValueInjecter;

namespace DigitalEventPlaner.Web.Helpers
{
    public static class GeneralHelper
    {
        public static List<EventWrapperViewModel> MapEventWrapperList(List<EventWrapper> eventWrappers)
        {
            var viewModelList = new List<EventWrapperViewModel>();

            foreach (var ew in eventWrappers)
            {
                var eventWrapper = new EventWrapperViewModel().InjectFrom(ew) as EventWrapperViewModel;
                eventWrapper.ServiceWrappers = MapServiceWrapperList(ew.ServiceWrappers);
                viewModelList.Add(eventWrapper);
            }

            return viewModelList;
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

        public static List<EventRequestViewModel> MapServiceRequestList(List<EventRequestDto> eventRequests)
        {
            var serviceViewModelList = new List<EventRequestViewModel>();
            foreach(var er in eventRequests)
            {
                var viewModel = new EventRequestViewModel().InjectFrom(er) as EventRequestViewModel;
                viewModel.EventService = new EventServiceViewModel().InjectFrom(er.EventService) as EventServiceViewModel;
                viewModel.ServiceWrapper = MapServiceWrapper(er.ServiceWrapper);
                serviceViewModelList.Add(viewModel);
            }
            return serviceViewModelList;
        }
    }
}
