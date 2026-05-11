# Implementation Notes

## Java implementation

- A Spring `StaticResourceConfig` serves download paths from the storage folder.
- A configured multi-registry storage root in the local filesystem (default path is `registry/`).
- A configured symlink maps `/terraform/registry.terraform.io` points to a subfolder `/terraform/`.
- The Terraform `RegistryService` expects terraform registry storage in the `/terraform/` subfolder.

- Terraform Providers are discovered from `/terraform/plugins/...`.
- Terraform Modules are discovered from `/terraform/modules/...`.
- A symlink `terraforn/providers` points to `plugins` so Terraform protocol paths remain compatible.

- API paths map `/v1/providers/...` -> `/terraform/providers/...`.
- API paths map `/v1/modules/...` -> `/terraform/modules/...`.

- A symlink `terraforn/providers` points to `plugins` so Terraform protocol paths remain compatible.
- Download URLs continue to reference `/terraform/providers/...`.

- Tests in `java-impl` use local registry storage and verify that provider indexes are built from the new layout.

## .NET implementation

- A configured multi-registry storage root in the local filesystem (default path is `registry/`).
- A configured symlink maps to `registry/registry.terraform.io/` -> `registry/terraform/`.
- The Terraform `RegistryService` expects terraform registry storage in the `/terraform/` subfolder.

- Terraform Providers are discovered from `/terraform/plugins/...`.
- Terraform Modules are discovered from `/terraform/modules/...`.

- API paths map `/v1/providers/...` -> `/terraform/providers/...`.
- API paths map `/v1/modules/...` -> `/terraform/modules/...`.

- A symlink `terraforn/providers` points to `plugins` so Terraform protocol paths remain compatible.
- Download URLs continue to reference `/terraform/providers/...`.

- Tests in `dotnet-impl/test` use local registry storage and verify that provider indexes are built from the new layout.


## Notes

- The current implementation is Terraform-specific, but the layout is designed to allow additional registry roots in the future.
- The symlink strategy preserves protocol compatibility without changing the external API surface.
- Implementation details are intentionally separated from the general design so the same abstract architecture can be reused for future registry types.
</content>
<parameter name="filePath">c:\work\workspace\dsp\cloud\iac\terra_incognita\proposed_structure_update.md